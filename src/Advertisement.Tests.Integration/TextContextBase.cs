using System.Collections.Generic;
using System.Linq;
using Advertisement.Domain;
using Advertisement.Interfaces;
using Advertisement.Tests.Integration.IoC;
using NUnit.Framework;
using Autofac;

namespace Advertisement.Tests.Integration
{
    internal class TestContextBase
    {
        private ICollection<ProductDto> _products;

        protected double ExpectedTotalAmount;

        protected double ActualTotalAmount;

        protected CheckOutProcessor CheckOutProcessor;

        public void Arrange(double expectedTotalAmount)
        {
            var container = IoCBootstrapper.Init();

            CheckOutProcessor = container.Resolve<CheckOutProcessor>();

            var productRepository = container.Resolve<IProductRepository>();

            _products = productRepository.GetProducts();

            ExpectedTotalAmount = expectedTotalAmount;
        }

        public void AssertTotalAmountIsCorrect()
        {
            Assert.AreEqual(ExpectedTotalAmount, ActualTotalAmount);
        }

        protected Product GetClassicAd()
        {
            var dto = _products.FirstOrDefault(p => p.ProductId == "classic");
            return new Product(dto.ProductId, dto.Price);
        }

        protected Product GetStandoutAd()
        {
            var dto = _products.FirstOrDefault(p => p.ProductId == "standout");
            return new Product(dto.ProductId, dto.Price);
        }

        protected Product GetPremiumAd()
        {
            var dto = _products.FirstOrDefault(p => p.ProductId == "premium");
            return new Product(dto.ProductId, dto.Price);
        }
    }
}
