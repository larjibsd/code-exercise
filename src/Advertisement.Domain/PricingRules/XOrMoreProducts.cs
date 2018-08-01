using System.Collections.Generic;
using System.Linq;

namespace Advertisement.Domain.PricingRules
{
    public class XOrMoreProducts : ISpecialPricingRule
    {
        private readonly string _applicableProductId;
        private readonly int _x;
        private readonly double _discountedPrice;

        public XOrMoreProducts(string applicableProductId, 
            int x, double discountedPrice)
        {
            _applicableProductId = applicableProductId;
            _x = x;
            _discountedPrice = discountedPrice;
        }

        public bool IsApplicable(IEnumerable<Product> products)
        {
            return products
                       .Count(i => i.ProductId == _applicableProductId) >= _x && _discountedPrice > 0;
        }

        public void Apply(ICollection<Product> products)
        {
            var applicableProducts = products.Where(i => i.ProductId == _applicableProductId);

            foreach (var product in applicableProducts)
            {
                product.UpdatePrice(_discountedPrice);
            }

        }
    }
}
