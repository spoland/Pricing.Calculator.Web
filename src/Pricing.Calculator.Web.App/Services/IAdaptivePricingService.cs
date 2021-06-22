using Pricing.Calculator.Web.App.Models.Response;
using System.Threading.Tasks;

namespace Pricing.Calculator.Web.App.Services
{
    public interface IAdaptivePricingService
    {
        Task<HistoricAdaptivePricing> Get(string countryIso);
    }
}