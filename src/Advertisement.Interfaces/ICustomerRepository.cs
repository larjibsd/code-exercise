using System.Collections.Generic;

namespace Advertisement.Interfaces
{
    public interface ICustomerRepository
    {
        CustomerDto GetCustomerById(long customerId);

        ICollection<PricingRuleDto> GetPricingRules(long customerId);
    }
}
