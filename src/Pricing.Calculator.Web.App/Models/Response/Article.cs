using System.Collections.Generic;
using System.Linq;

namespace Pricing.Calculator.Web.App.Models.Response
{
    public record Article
    {
        public Article(IEnumerable<Charge> charges)
        {
            var workingCharges = charges.ToList();

            // fix these by returning and mapping 'input charge name' from api

            var totalItemCharge = charges
                .Where(c => c.Name.Contains("Item"))
                .Aggregate(new Charge("", new Price("EUR", 0)), (total, next) => new Charge("TotalItem", new Price("EUR", total.Amount.Value + next.Amount.Value)));

            var totalDeliveryCharge = charges
                .Where(c => c.Name.Contains("Delivery"))
                .Aggregate(new Charge("", new Price("EUR", 0)), (total, next) => new Charge("TotalDelivery", new Price("EUR", total.Amount.Value + next.Amount.Value)));

            if (totalItemCharge.Amount.Value > 0) workingCharges.Add(totalItemCharge);
            if (totalDeliveryCharge.Amount.Value > 0) workingCharges.Add(totalDeliveryCharge);

            Charges = workingCharges;
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
