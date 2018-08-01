using Advertisement.Domain.PricingRules;
using Advertisement.Interfaces;

namespace Advertisement.Domain
{
    public class PricingRuleFactory
    {
        public static ISpecialPricingRule Create(PricingRuleDto dto)
        {
            var pricingRuleType = (PricingRuleType) dto.PricingRuleType;

            switch (pricingRuleType)
            {
                case PricingRuleType.DiscountPerProduct:
                    return new DiscountPerProduct(dto.ProductId, dto.DiscountedPrice.Value);

                case PricingRuleType.XForYFreeProduct:
                    return new XForYFreeProducts(dto.ProductId, dto.XForYFreeAdvertisementXValue.Value,
                        dto.XForYFreeAdvertisementYValue.Value);

                case PricingRuleType.XOrMoreProducts:
                    return new XOrMoreProducts(dto.ProductId, dto.XOrMoreAdvertisementXValue.Value,
                        dto.DiscountedPrice.Value);

                default:
                    return null;
            }
        }
    }
}