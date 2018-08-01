using System.Collections.Generic;
using System.Linq;

namespace Advertisement.Domain.PricingRules
{
    public class XForYFreeProducts : ISpecialPricingRule
    {
        private readonly string _applicableProductId;
        private readonly int _x;
        private readonly int _y;

        public XForYFreeProducts(string applicableProductId, int x, int y)
        {
            _applicableProductId = applicableProductId;
            _x = x;
            _y = y;
        }


        public bool IsApplicable(IEnumerable<Product> products)
        {
            return products
                       .Count(i => i.ProductId == _applicableProductId) / _y > 0;
        }

        public void Apply(ICollection<Product> products)
        {
            var applicableProducts = products.Where(i => i.ProductId == _applicableProductId).ToList();

            var count = applicableProducts.Count();

            var applicableCount = count / _x * _y + count % _x;

            foreach (var product in applicableProducts) products.Remove(product);

            for (var i = 0; i < applicableCount; i++)
            {
                products.Add(new Product(applicableProducts.First().ProductId,
                    applicableProducts.First().Price));
            }
        }
    }
}