using System.Collections.Generic;
using System.Linq;
using Advertisement.Domain;
using AutoFixture;
using AutoFixture.AutoRhinoMock;
using NUnit.Framework;
using Rhino.Mocks;

namespace Advertisement.Tests.Unit.Domain
{
    [TestFixture]
    public class CheckoutTests
    {
        [SetUp]
        public void SetUp()
        {
            _context = new TestContext();
        }

        private TestContext _context;

        private class TestContext
        {
            private IFixture _fixture;
            private ISpecialPricingRule _pricingRule;
            private Product _product;
            private Checkout _sut;
            private double _total;

            public void ArrangeWhenPriceApplies()
            {
                _fixture = new Fixture();

                _fixture.Customize(new AutoRhinoMockCustomization());

                _pricingRule = _fixture.Create<ISpecialPricingRule>();

                _product = _fixture.Create<Product>();

                _pricingRule.Stub(r =>
                        r.IsApplicable(
                            Arg<ICollection<Product>>.Matches(p => p.First().ProductId == _product.ProductId)))
                    .Return(true);

                _pricingRule.Expect(r =>
                    r.Apply(Arg<ICollection<Product>>.Matches(p => p.First().ProductId == _product.ProductId)));

                _sut = new Checkout(new List<ISpecialPricingRule> {_pricingRule});

                _sut.AddItem(_product);
            }

            public void Act()
            {
                _total = _sut.Total();
            }

            public void AssertWhenPriceApplies()
            {
                _pricingRule.VerifyAllExpectations();
                Assert.AreEqual(_product.Price, _total);
            }
        }

        [Test]
        public void Assert_when_pricing_rule_applies_amount_is_correct()
        {
            _context.ArrangeWhenPriceApplies();

            _context.Act();

            _context.AssertWhenPriceApplies();
        }
    }
}