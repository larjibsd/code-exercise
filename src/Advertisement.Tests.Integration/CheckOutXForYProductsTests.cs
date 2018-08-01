using System.Collections.Generic;
using Advertisement.Domain;
using NUnit.Framework;

namespace Advertisement.Tests.Integration
{
    [TestFixture]
    public class CheckOutXForYProductsTests
    {
        private TestContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new TestContext();
        }

        [Test]
        public void Test_checkout_total_when_x_for_y_product_pricing_rule_applies()
        {
            _context.Arrange();

            _context.Act();

            _context.AssertTotalAmountIsCorrect();
        }


        private class TestContext : TestContextBase
        {
            public void Arrange()
            {
                base.Arrange(934.97);
            }

            public void Act()
            {
                var products = new List<Product>()
                {
                    GetClassicAd(),
                    GetClassicAd(),
                    GetClassicAd(),
                    GetPremiumAd()
                };

                ActualTotalAmount = CheckOutProcessor.GetTotal(1, products);
            }
        }
    }
}