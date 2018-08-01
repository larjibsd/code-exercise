namespace Advertisement.Interfaces
{
    public class PricingRuleDto
    {
        public long RuleId { get; set; }

        public long CustomerId { get; set; }

        public string ProductId { get; set; }

        public int PricingRuleType { get; set; }

        public double? DiscountedPrice { get; set; }

        public int? XForYFreeAdvertisementXValue { get; set; }

        public int? XForYFreeAdvertisementYValue { get; set; }

        public int? XOrMoreAdvertisementXValue { get; set; }
    }
}
