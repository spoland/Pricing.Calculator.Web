using Pricing.Calculator.Web.App.Models.Response;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Pricing.Calculator.Web.App.Services
{
    public class AdaptivePricingService : IAdaptivePricingService
    {
        private readonly HttpClient _httpClient;

        public AdaptivePricingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HistoricAdaptivePricing?> Get()
        {
            var data = await _httpClient.GetFromJsonAsync<HistoricAdaptivePricing>("/api/1.0/Actions/calculate/AdaptivePricingHistory");
            return data;
        }
    }
}
