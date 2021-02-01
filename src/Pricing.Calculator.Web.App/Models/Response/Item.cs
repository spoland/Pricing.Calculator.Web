using System.Collections.Generic;
using System.Linq;

namespace Pricing.Calculator.Web.App.Models.Response
{
    public class Item
    {
        public Item(IEnumerable<Article> articles)
        {
            Articles = articles;
        }

        public IEnumerable<Article> Articles { get; }

        public IEnumerable<string> ChargeNames()
        {
            return Articles
                .SelectMany(a => a.Charges)
                .Select(c => c.Name)
                .Distinct()
                .ToList() ?? new List<string>();
        }

        public decimal GetChargeAmount(string chargeName) =>
            Articles.Sum(a => a.GetChargeAmount(chargeName));
    }
}
