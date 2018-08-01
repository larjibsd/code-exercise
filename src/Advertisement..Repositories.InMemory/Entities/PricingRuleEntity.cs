namespace Advertisement.Repositories.InMemory.Entities
{
    public class PricingRuleEntity
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