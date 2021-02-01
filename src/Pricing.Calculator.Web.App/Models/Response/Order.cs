using System.Collections.Generic;

namespace Pricing.Calculator.Web.App.Models.Response
{
    public class Order
    {
        public Order(string id, IEnumerable<Item> items)
        {
            Id = id;
            Items = items;
        }

        public string Id { get; }

        public IEnumerable<Item> Items { get; }
    }
}
