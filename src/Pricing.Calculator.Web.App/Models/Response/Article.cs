using System.Collections.Generic;
using System.Linq;

namespace Pricing.Calculator.Web.App.Models.Response
{
    public record Article
    {
        public Article(IEnumerable<Charge> charges)
        {
            Charges = charges;
        }

        public IEnumerable<Charge> Charges { get; }

        public decimal GetChargeAmount(string chargeName)
        {
            return Charges
                .Where(c => c.Name == chargeName)
                .Sum(c => c.Amount.Value);
        }
    }
}
