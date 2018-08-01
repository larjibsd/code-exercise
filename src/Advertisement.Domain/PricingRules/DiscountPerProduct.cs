using System.Collections.Generic;
using System.Linq;

namespace Advertisement.Domain.PricingRules
{
    public class DiscountPerProduct : ISpecialPricingRule
    {
        private readonly string _applicableProductId;
        private readonly double _discountedPrice;

        public DiscountPerProduct(string applicableProductId, double discountedPrice)
        {
            _applicableProductId = applicableProductId;
            _discountedPrice = discountedPrice;
        }

        public bool IsApplicable(IEnumerable<Product> products)
        {
            return products.Any(p => p.ProductId == _applicableProductId && _discountedPrice > 0);
        }

        public void Apply(ICollection<Product> products)
        {
            var applicableProducts = products.Where(i => i.ProductId == _applicableProductId);

            foreach (var product in applicableProducts) product.UpdatePrice(_discountedPrice);
        }
    }
}