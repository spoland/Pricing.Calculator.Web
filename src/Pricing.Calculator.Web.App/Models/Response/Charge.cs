namespace Pricing.Calculator.Web.App.Models.Response
{
    public class Charge
    {
        public Charge(string name, Price amount)
        {
            Name = name;
            Amount = amount;
        }

        public string Name { get; }

        public Price Amount { get; }
    }
}
