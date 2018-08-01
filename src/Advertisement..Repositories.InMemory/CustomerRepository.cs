using System;
using System.Collections.Generic;
using System.Linq;
using Advertisement.Interfaces;
using Advertisement.Repositories.InMemory.Entities;
using Advertisement.Repositories.InMemory.Factories;

namespace Advertisement.Repositories.InMemory
{
    public class CustomerRepository : ICustomerRepository
    {
        private ICollection<CustomerEntity> _customers;
        private ICollection<PricingRuleEntity> _pricingRules;

        public CustomerRepository()
        {
            InitialiseDb();
        }

        public CustomerDto GetCustomerById(long customerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<PricingRuleDto> GetPricingRules(long customerId)
        {
            return _pricingRules
                .Where(r => r.CustomerId == customerId)
                .Select(PricingRuleDtoFactory.Create).ToList();
        }

        private void InitialiseDb()
        {
            _customers = new List<CustomerEntity>();

            InsertCustomer(1, "Unilever");
            InsertCustomer(2, "Apple");
            InsertCustomer(3, "Nike");
            InsertCustomer(4, "Ford");
            InsertCustomer(5, "Default");

            _pricingRules = new List<PricingRuleEntity>();

            InsertPricingRules(1, 1, "classic", 2, null, 3, 2, null);
            InsertPricingRules(2, 2, "standout", 1, 299.99, null, null, null);
            InsertPricingRules(3, 3, "premium", 3, 379.99, null, null, 4);
            InsertPricingRules(4, 4, "classic", 2, null, 5, 4, null);
            InsertPricingRules(5, 4, "standout", 1, 309.99, null, null, null);
            InsertPricingRules(6, 4, "premium", 3, 389.99, null, null, 3);
        }

        private void InsertCustomer(long customerId, string customerName)
        {
            _customers.Add(new CustomerEntity
            {
                CustomerId = customerId,
                CustomerName = customerName
            });
        }

        private void InsertPricingRules(long ruleId, long customerId, string productId,
            int pricingRuleType, double? discountedPrice, int? xForYFreeAdvertisementXValue,
            int? xForYFreeAdvertisementYValue, int? xOrMoreAdvertisementXValue)
        {
            _pricingRules.Add(new PricingRuleEntity
            {
                RuleId = ruleId,
                CustomerId = customerId,
                ProductId = productId,
                PricingRuleType = pricingRuleType,
                DiscountedPrice = discountedPrice,
                XForYFreeAdvertisementXValue = xForYFreeAdvertisementXValue,
                XForYFreeAdvertisementYValue = xForYFreeAdvertisementYValue,
                XOrMoreAdvertisementXValue = xOrMoreAdvertisementXValue
            });
        }
    }
}