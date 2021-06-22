using Pricing.Calculator.Web.App.Models.Response;
using Syncfusion.Blazor.Data;
using System.Linq;
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

        public async Task<HistoricAdaptivePricing> Get(string countryIso)
        {
            var data = await _httpClient.GetFromJsonAsync<HistoricAdaptivePricing>($"/api/1.0/Actions/calculate/AdaptivePricingHistory?countryIso={countryIso}");
            data.AdaptivePricingData = data.AdaptivePricingData.OrderBy(d => d.Timestamp).ToList();
            return data ?? new HistoricAdaptivePricing();
        }
    }
}
