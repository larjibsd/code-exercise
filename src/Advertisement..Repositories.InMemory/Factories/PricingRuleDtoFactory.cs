using Advertisement.Interfaces;
using Advertisement.Repositories.InMemory.Entities;

namespace Advertisement.Repositories.InMemory.Factories
{
    public class PricingRuleDtoFactory
    {
        public static PricingRuleDto Create(PricingRuleEntity pricingRuleEntity)
        {
            return new PricingRuleDto()
            {
                RuleId = pricingRuleEntity.RuleId,
                CustomerId = pricingRuleEntity.CustomerId,
                ProductId = pricingRuleEntity.ProductId,
                PricingRuleType = pricingRuleEntity.PricingRuleType,
                DiscountedPrice = pricingRuleEntity.DiscountedPrice,
                XForYFreeAdvertisementXValue = pricingRuleEntity.XForYFreeAdvertisementXValue,
                XForYFreeAdvertisementYValue = pricingRuleEntity.XForYFreeAdvertisementYValue,
                XOrMoreAdvertisementXValue = pricingRuleEntity.XOrMoreAdvertisementXValue
            };
        }
    }
}