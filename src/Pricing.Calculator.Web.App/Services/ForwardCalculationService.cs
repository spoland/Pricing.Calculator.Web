using Microsoft.AspNetCore.Mvc;
using Pricing.Calculator.Web.App.Models.Request.Forward;
using Pricing.Calculator.Web.App.Models.Response;
using Pricing.Calculator.Web.App.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Pricing.Calculator.Web.App.Forward
{
    public class ForwardCalculationService : IForwardCalculationService
    {
        private readonly HttpClient _httpClient;

        public ForwardCalculationService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<OperationResult> Calculate(Models.Request.Forward.Order request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/1.0/Actions/calculate/forward", request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var calculation = await response.Content.ReadFromJsonAsync<Calculation>(null, cancellationToken);

                if (calculation is not null)
                    return OperationResult<Calculation>.Success(calculation);

                return OperationResult.Fail(new Dictionary<string, string[]>
                {
                    { "Serialization Error", new [] { "Unable to deserialize response." } }
                });
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var problemDetails = await response.Content.ReadFromJsonAsync<ValidationProblemDetails>(null, cancellationToken);

                if (problemDetails is not null)
                    return OperationResult.Fail(problemDetails.Errors);

                return OperationResult.Fail(new Dictionary<string, string[]>
                {
                    { "Bad Request", new [] { "Unable to deserialize validation errors in response." } }
                });
            }

            return OperationResult.Fail(new Dictionary<string, string[]>
            {
                { "Unknown Failure", new [] { "An unknown failure has occurred." } }
            });
        }
    }
}
