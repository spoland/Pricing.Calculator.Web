namespace Pricing.Calculator.Web.App.Models.Response
{
    public class Calculation
    {
        public Calculation(
            string id,
            string rulesetId,
            string rulesetVersion,
            Order order)
        {
            Id = id;
            RulesetId = rulesetId;
            RulesetVersion = rulesetVersion;
            Order = order;
        }

        public string Id { get; }

        public string RulesetId { get; }

        public string RulesetVersion { get; }

        public Order Order { get; }
    }
}
