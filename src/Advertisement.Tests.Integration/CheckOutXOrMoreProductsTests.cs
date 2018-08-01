using System.Collections.Generic;
using Advertisement.Domain;
using NUnit.Framework;

namespace Advertisement.Tests.Integration
{
    [TestFixture]
    public class CheckOutXOrMoreProductsTests
    {
        private TestContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new TestContext();
        }

        [Test]
        public void Test_checkout_total_when_x_or_more_products_pricing_rule_applies()
        {
            _context.Arrange();

            _context.Act();

            _context.AssertTotalAmountIsCorrect();
        }


        private class TestContext : TestContextBase
        {
            public void Arrange()
            {
                base.Arrange(1519.96);
            }

            public void Act()
            {
                var products = new List<Product>()
                {
                    GetPremiumAd(),
                    GetPremiumAd(),
                    GetPremiumAd(),
                    GetPremiumAd()
                };

                ActualTotalAmount = CheckOutProcessor.GetTotal(3, products);
            }
        }
    }
}