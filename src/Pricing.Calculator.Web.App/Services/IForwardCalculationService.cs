using Pricing.Calculator.Web.App.Models.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Pricing.Calculator.Web.App.Services
{
    public interface IForwardCalculationService
    {
        public Task<OperationResult> Calculate(Models.Request.Forward.Order request, CancellationToken cancellationToken);
    }
}