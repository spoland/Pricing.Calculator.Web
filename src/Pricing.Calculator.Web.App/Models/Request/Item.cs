using System.ComponentModel.DataAnnotations;

namespace Pricing.Calculator.Web.App.Models.Request
{
    public class Item
    {
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        [Range(1, double.MaxValue, ErrorMessage = "The {0} field must be at least {1}.")]
        public int Quantity { get; set; }

        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "The {0} field must be greater than 0.")]
        public decimal Weight { get; set; }

        [Range(0, 100, ErrorMessage = "The {0} field must have a value of between 0-100.")]
        public decimal DutyRate { get; set; }

        [Range(0, 100, ErrorMessage = "The {0} field must have a value of between 0-100.")]
        public decimal VatRate { get; set; }

        [Required]
        public Price InputPrice { get; set; } = new Price();

        [Required]
        public Price InputDeliveryPrice { get; set; } = new Price();

        public string HsCode { get; set; } = System.Guid.NewGuid().ToString();

        public string CountryOfOrigin { get; set; } = "CN";
    }
}
