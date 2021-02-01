using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pricing.Calculator.Web.App.Models.Request.Forward
{
    public class Order : IValidatableObject
    {
        public Order()
        {
            Items = new List<Item>
            {
                new Item
                {
                    DutyRate = 10,
                    InputDeliveryPrice = new Price { Value = 100 },
                    InputPrice = new Price { Value = 1000 },
                    Quantity = 2,
                    VatRate = 20,
                    Weight = 1
                }
            };
        }

        public string OrderId => Guid.NewGuid().ToString();

        public string CurrencyIso => "EUR";

        [Required]
        public string SourceCountryIso { get; set; } = string.Empty;

        [Required]
        public string DeclarationCountryIso { get; set; } = string.Empty;

        [ValidateComplexType]
        public List<Item> Items { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Items.Any())
                yield return new ValidationResult(errorMessage: "At least one item must be added to the order!", new[] { nameof(Items) });
        }
    }
}
