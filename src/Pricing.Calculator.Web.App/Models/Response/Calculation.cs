using System.Collections.Generic;

namespace Pricing.Calculator.Web.App.Models.Response
{
    public class Calculation
    {
        public Calculation(
            string id,
            string rulesetId,
            string rulesetVersion,
            Order order,
            IEnumerable<string> events)
        {
            Id = id;
            RulesetId = rulesetId;
            RulesetVersion = rulesetVersion;
            Order = order;
            Events = events;
        }

        public string Id { get; }

        public string RulesetId { get; }

        public string RulesetVersion { get; }

        public Order Order { get; }

        public IEnumerable<string> Events { get; }
    }
}
