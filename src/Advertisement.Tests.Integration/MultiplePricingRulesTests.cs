using System;
using System.Collections.Generic;
using Advertisement.Domain;
using NUnit.Framework;

namespace Advertisement.Tests.Integration
{
    [TestFixture]
    public class MultiplePricingRulesTests
    {
        [SetUp]
        public void SetUp()
        {
            _context = new TestContext();
        }

        private TestContext _context;


        private class TestContext : TestContextBase
        {
            public void Arrange()
            {
                base.Arrange(3219.90);
            }

            public void Act()
            {
                var products = new List<Product>
                {
                    GetClassicAd(),
                    GetClassicAd(),
                    GetClassicAd(),
                    GetClassicAd(),
                    GetClassicAd(),
                    GetClassicAd(),

                    GetStandoutAd(),

                    GetPremiumAd(),
                    GetPremiumAd(),
                    GetPremiumAd(),
                    GetPremiumAd()
                };

                ActualTotalAmount = Math.Round(CheckOutProcessor.GetTotal(4, products),2);
            }
        }

        [Test]
        public void Test_checkout_total_when_multiple_pricing_rules_apply()
        {
            _context.Arrange();

            _context.Act();

            _context.AssertTotalAmountIsCorrect();
        }
    }
}