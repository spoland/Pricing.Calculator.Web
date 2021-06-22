using System.Collections.Generic;

namespace Pricing.Calculator.Web.App.Models.Response
{
    public class HistoricAdaptivePricing
    {
        public List<AdaptivePricing> AdaptivePricingData { get; set; } = new List<AdaptivePricing>();
    }

    public class AdaptivePricing
    {
        public string Id { get; set; } = string.Empty;

        public string OrderId { get; set; } = string.Empty;

        public decimal Merchandise { get; set; }

        public decimal Duties { get; set; }

        public decimal Taxes { get; set; }

        public decimal Fees { get; set; }

        public decimal FixedUpliftEstimate { get; set; }

        public decimal FixedEstimatedPrice { get; set; }

        public decimal RealUplift { get; set; }

        public decimal AdaptiveUpliftEstimate { get; set; }

        public decimal AdaptiveEstimatedPrice { get; set; }

        public decimal RealPrice { get; set; }

        public decimal DiffAdaptive { get; set; }

        public decimal DiffFixed { get; set; }

        public decimal DiffAdaptivePercentage { get; set; }

        public decimal DiffFixedPercentage { get; set; }
    }
}
