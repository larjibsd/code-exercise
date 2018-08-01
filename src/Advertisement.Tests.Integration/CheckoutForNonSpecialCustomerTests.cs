using System.Collections.Generic;
using Advertisement.Domain;
using NUnit.Framework;

namespace Advertisement.Tests.Integration
{
    [TestFixture]
    public class CheckoutForNonSpecialCustomerTests
    {
        private TestContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new TestContext();
        }

        [Test]
        public void Test_checkout_total_when_customer_is_not_special_no_special_pricing_should_apply()
        {
            _context.Arrange();

            _context.Act();

            _context.AssertTotalAmountIsCorrect();
        }


        private class TestContext : TestContextBase
        {
            public void Arrange()
            {
                base.Arrange(2963.91);
            }

            public void Act()
            {
                var products = new List<Product>()
                {
                    GetClassicAd(),
                    GetClassicAd(),
                    GetClassicAd(),
                    GetStandoutAd(),
                    GetStandoutAd(),
                    GetStandoutAd(),
                    GetPremiumAd(),
                    GetPremiumAd(),
                    GetPremiumAd()
                };

                ActualTotalAmount = CheckOutProcessor.GetTotal(5, products);
            }
        }
    }
}