namespace Pricing.Calculator.Web.App.Models.Response
{
    public class Price
    {
        public Price(string currencyIso, decimal value)
        {
            CurrencyIso = currencyIso;
            Value = value;
        }

        public string CurrencyIso { get; } = string.Empty;

        public decimal Value { get; }
    }
}
