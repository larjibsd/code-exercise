using System.Collections.Generic;
using Advertisement.Domain;
using NUnit.Framework;

namespace Advertisement.Tests.Integration
{
    [TestFixture]
    public class CheckOutDiscountPerProductTests
    {
        private TestContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new TestContext();
        }

        [Test]
        public void Test_checkout_total_when_discount_per_product_pricing_rule_applies()
        {
            _context.Arrange();

            _context.Act();

            _context.AssertTotalAmountIsCorrect();
        }


        private class TestContext : TestContextBase
        {
            public void Arrange()
            {
                base.Arrange(1294.96);
            }

            public void Act()
            {
                var products = new List<Product>()
                {
                    GetStandoutAd(),
                    GetStandoutAd(),
                    GetStandoutAd(),
                    GetPremiumAd()
                };

                ActualTotalAmount = CheckOutProcessor.GetTotal(2, products);
            }
        }
    }
}