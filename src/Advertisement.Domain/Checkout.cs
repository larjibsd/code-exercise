using System.Collections.Generic;
using System.Linq;
using Advertisement.Domain.PricingRules;

namespace Advertisement.Domain
{
    public class Checkout
    {
        private readonly ICollection<ISpecialPricingRule> _specialPricingRule;
        private readonly ICollection<Product> _products;

        public Checkout(ICollection<ISpecialPricingRule> specialPricingRule)
        {
            _specialPricingRule = specialPricingRule;
            _products = new List<Product>();
        }

        public void AddItem(Product product)
        {
            _products.Add(product);
        }

        public double Total()
        {
            foreach (var pricingRule in
                _specialPricingRule.Where(pricingRule =>
                    pricingRule.IsApplicable(_products)))
            {
                pricingRule.Apply(_products);
            }

            return _products.Sum(i => i.Price);
        }
    }
}