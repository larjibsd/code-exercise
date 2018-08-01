using Advertisement.Domain;
using Advertisement.Domain.PricingRules;
using Advertisement.Interfaces;
using AutoFixture;
using NUnit.Framework;

namespace Advertisement.Tests.Unit.Domain
{
    [TestFixture]
    public class PricingRuleFactoryTests
    {
        [SetUp]
        public void SetUp()
        {
            _testContext = new TestContext();
        }

        private TestContext _testContext;

        private class TestContext
        {
            private readonly IFixture _fixture;
            private PricingRuleDto _pricingRuleDto;
            private ISpecialPricingRule _specialPricingRule;


            public TestContext()
            {
                _fixture = new Fixture();
            }

            public void ArrangeDiscountPerProductPricing()
            {
                _fixture.Customize<PricingRuleDto>(s =>
                    s.With(p => p.PricingRuleType, (int) PricingRuleType.DiscountPerProduct)
                        .With(p => p.DiscountedPrice, 100.50));

                _pricingRuleDto = _fixture.Create<PricingRuleDto>();
            }

            public void ArrangeXForYFreeProductPricing()
            {
                _fixture.Customize<PricingRuleDto>(s =>
                    s.With(p => p.PricingRuleType, (int) PricingRuleType.XForYFreeProduct)
                        .With(p => p.XForYFreeAdvertisementXValue, 3)
                        .With(p => p.XForYFreeAdvertisementYValue, 2));

                _pricingRuleDto = _fixture.Create<PricingRuleDto>();
            }

            public void ArrangeXOrMoreProductsPricing()
            {
                _fixture.Customize<PricingRuleDto>(s =>
                    s.With(p => p.PricingRuleType, (int) PricingRuleType.XOrMoreProducts)
                        .With(p => p.XOrMoreAdvertisementXValue, 3)
                        .With(p => p.DiscountedPrice, 200.50));

                _pricingRuleDto = _fixture.Create<PricingRuleDto>();
            }

            public void ArrangeNonExistingPricingRule()
            {
                _fixture.Customize<PricingRuleDto>(s =>
                    s.With(p => p.PricingRuleType, 100));

                _pricingRuleDto = _fixture.Create<PricingRuleDto>();
            }

            public void Act()
            {
                _specialPricingRule = PricingRuleFactory.Create(_pricingRuleDto);
            }

            public void AssertDiscountPerProductPricingRuleIsCreated()
            {
                Assert.IsInstanceOf<DiscountPerProduct>(_specialPricingRule);
            }

            public void AssertXForYFreeProductPricingRuleIsCreated()
            {
                Assert.IsInstanceOf<XForYFreeProducts>(_specialPricingRule);
            }

            public void AssertXOrMoreProductsPricingRuleIsCreated()
            {
                Assert.IsInstanceOf<XOrMoreProducts>(_specialPricingRule);
            }

            public void AssertNoPricingRuleIsCreated()
            {
                Assert.IsNull(_specialPricingRule);
            }
        }

        [Test]
        public void Assert_discount_per_product_pricing_rule_is_created()
        {
            _testContext.ArrangeDiscountPerProductPricing();

            _testContext.Act();

            _testContext.AssertDiscountPerProductPricingRuleIsCreated();
        }

        [Test]
        public void Assert_no_pricing_rule_is_created()
        {
            _testContext.ArrangeNonExistingPricingRule();

            _testContext.Act();

            _testContext.AssertNoPricingRuleIsCreated();
        }

        [Test]
        public void Assert_x_for_y_free_product_pricing_rule_is_created()
        {
            _testContext.ArrangeXForYFreeProductPricing();

            _testContext.Act();

            _testContext.AssertXForYFreeProductPricingRuleIsCreated();
        }

        [Test]
        public void Assert_x_or_more_products_pricing_rule_is_created()
        {
            _testContext.ArrangeXOrMoreProductsPricing();

            _testContext.Act();

            _testContext.AssertXOrMoreProductsPricingRuleIsCreated();
        }
    }
}