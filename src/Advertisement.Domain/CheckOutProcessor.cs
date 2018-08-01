using System.Collections.Generic;
using System.Linq;
using Advertisement.Interfaces;

namespace Advertisement.Domain
{
    public class CheckOutProcessor
    {
        private readonly ICustomerRepository _customerRepository;

        public CheckOutProcessor(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public double GetTotal(long customerId, List<Product> products)
        {
            var pricingRulesDtos = _customerRepository.GetPricingRules(customerId);

            var pricingRules = pricingRulesDtos.Select(PricingRuleFactory.Create);

            var checkout = new Checkout(pricingRules.ToList());

            foreach (var product in products)
            {
                checkout.AddItem(product);
            }

            return checkout.Total();
        }
    }
}