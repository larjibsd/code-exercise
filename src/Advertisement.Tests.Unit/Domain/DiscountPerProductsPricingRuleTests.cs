using System.Collections.Generic;
using System.Linq;
using Advertisement.Domain;
using Advertisement.Domain.PricingRules;
using AutoFixture;
using NUnit.Framework;

namespace Advertisement.Tests.Unit.Domain
{
    [TestFixture]
    public class DiscountPerProductsPricingRuleTests
    {
        [SetUp]
        public void SetUp()
        {
            _testContext = new TestContext();
        }

        private TestContext _testContext;

        private class TestContext
        {
            private IFixture _fixture;
            private bool _isApplicable;
            private List<Product> _products;
            private DiscountPerProduct _sut;


            public void Arrange(string applicableProductId, string productId)
            {
                _fixture = new Fixture();

                _fixture.Register(() => new Product(productId, 120.75));

                _products = _fixture.CreateMany<Product>().ToList();

                _sut = new DiscountPerProduct(applicableProductId, 100.65);
            }


            public void ActIsApplicable()
            {
                _isApplicable = _sut.IsApplicable(_products);
            }

            public void ActApply()
            {
                _sut.Apply(_products);
            }

            public void AssertIsApplicable(bool expectedIsApplicable)
            {
                Assert.AreEqual(expectedIsApplicable, _isApplicable);
            }

            public void AssertProductPriceIsUpdated()
            {
                foreach (var product in _products) Assert.AreEqual(100.65, product.Price);
            }

            public void AssertProductPriceIsNotUpdated()
            {
                foreach (var product in _products) Assert.AreEqual(120.75, product.Price);
            }
        }

        [Test]
        public void Test_after_applying_product_price_is_not_updated()
        {
            _testContext.Arrange("classic", "blah");

            _testContext.ActApply();

            _testContext.AssertProductPriceIsNotUpdated();
        }

        [Test]
        public void Test_after_applying_product_price_is_updated()
        {
            _testContext.Arrange("classic", "classic");

            _testContext.ActApply();

            _testContext.AssertProductPriceIsUpdated();
        }

        [Test]
        [TestCase("classic", "classic", true)]
        [TestCase("blah", "classic", false)]
        public void Test_is_applicable(string applicableProductId, string productId, bool expected)
        {
            _testContext.Arrange(applicableProductId, productId);

            _testContext.ActIsApplicable();

            _testContext.AssertIsApplicable(expected);
        }
    }
}