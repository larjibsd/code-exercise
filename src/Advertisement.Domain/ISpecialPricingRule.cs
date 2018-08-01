using System.Collections.Generic;

namespace Advertisement.Domain
{
    public interface ISpecialPricingRule
    {
        bool IsApplicable(IEnumerable<Product> products);

        void Apply(ICollection<Product> products);
    }
}
