//using System.Collections.Generic;
//using System.Linq;
//using Advertisement.Domain;
//using Advertisement.Domain.PricingRules;
//using AutoFixture;
//using NUnit.Framework;

//namespace Advertisement.Tests.Unit.Domain
//{
//    [TestFixture]
//    public class XForYFreeProductsPricingRuleTests
//    {
//        [SetUp]
//        public void SetUp()
//        {
//            _testContext = new TestContext();
//        }

//        private TestContext _testContext;

//        private class TestContext
//        {
//            private IFixture _fixture;
//            private bool _isApplicable;
//            private List<Product> _products;
//            private XForYFreeProducts _sut;


//            public void Arrange(string applicableProductId, string productId, int x, int y)
//            {
//                _fixture = new Fixture();

//                _fixture.Register(() => new Product(productId, 100.55));

//                _products = _fixture.CreateMany<Product>().ToList();

//                _sut = new XForYFreeProducts(applicableProductId, x, y);
//            }

//            public void ArrangeRuleIsApplicable()
//            {
//                Arrange("classic", "classic", 3, 2);
//            }


//            public void ActIsApplicable()
//            {
//                _isApplicable = _sut.IsApplicable(_products);
//            }

//            public void ActApply()
//            {
//                _sut.Apply(_products);
//            }

//            public void AssertIsApplicable(bool expectedIsApplicable)
//            {
//                Assert.AreEqual(expectedIsApplicable, _isApplicable);
//            }

//            public void AssertProductPriceIsUpdated()
//            {
//                foreach (var product in _products)
//                {
//                    Assert.AreEqual(80.55, product.Price);
//                }
//            }

//            public void AssertProductPriceIsNotUpdated()
//            {
//                foreach (var product in _products)
//                {
//                    Assert.AreEqual(100.55, product.Price);
//                }
//            }
//        }

//        [Test]
//        [TestCase("classic", "classic", ,y,true)]
//        [TestCase("blah", "classic", false)]
//        public void Test_is_applicable(string applicableProductId, string productId, int x, int y, bool expected)
//        {
//            _testContext.Arrange(applicableProductId, productId, x, y);

//            _testContext.ActIsApplicable();

//            _testContext.AssertIsApplicable(expected);
//        }

//        [Test]
//        public void Test_after_applying_product_price_is_updated()
//        {
//            _testContext.Arrange("classic", "classic");

//            _testContext.ActApply();

//            _testContext.AssertProductPriceIsUpdated();
//        }

//        [Test]
//        public void Test_after_applying_product_price_is_not_updated()
//        {
//            _testContext.Arrange("classic", "blah");

//            _testContext.ActApply();

//            _testContext.AssertProductPriceIsNotUpdated();
//        }
//    }
//}
