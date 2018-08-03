using System.Collections.Generic;
using System.Linq;
using Advertisement.Domain;
using Advertisement.Domain.PricingRules;
using AutoFixture;
using NUnit.Framework;

namespace Advertisement.Tests.Unit.Domain
{
    [TestFixture]
    public class XForYFreeProductsPricingRuleTests
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
            private XForYFreeProducts _sut;


            public void Arrange(string applicableProductId, string productId, int numberOfProducts, int x, int y)
            {
                _fixture = new Fixture();

                _fixture.Register(() => new Product(productId, 100.55));

                _products = _fixture.CreateMany<Product>(numberOfProducts).ToList();

                _sut = new XForYFreeProducts(applicableProductId, x, y);
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

            public void AssertProductCountIsCorrect(int expectedNumberOfProducts)
            {
                Assert.AreEqual(expectedNumberOfProducts, _products.Count);
                foreach (var product in _products) Assert.AreEqual(100.55, product.Price);
            }
        }

        [Test]
        [TestCase("classic", "classic", 4, 3, 2, true)]
        [TestCase("classic", "classic", 2, 3, 4, false)]
        [TestCase("blah", "classic", 4, 3, 2, false)]
        public void Test_is_applicable(string applicableProductId, string productId, int numberOfProducts, int x,
            int y, bool expected)
        {
            _testContext.Arrange(applicableProductId, productId, numberOfProducts, x, y);

            _testContext.ActIsApplicable();

            _testContext.AssertIsApplicable(expected);
        }

        [Test]
        public void Test_when_rule_applies_product_count_is_updated()
        {
            _testContext.Arrange("classic", "classic", 3, 3, 2);

            _testContext.ActApply();

            _testContext.AssertProductCountIsCorrect(2);
        }
    }
}