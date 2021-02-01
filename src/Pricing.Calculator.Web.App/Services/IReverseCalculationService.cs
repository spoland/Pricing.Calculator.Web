using Pricing.Calculator.Web.App.Models.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Pricing.Calculator.Web.App.Services
{
    public interface IReverseCalculationService
    {
        public Task<OperationResult> Calculate(Models.Request.Reverse.Order request, CancellationToken cancellationToken);
    }
}