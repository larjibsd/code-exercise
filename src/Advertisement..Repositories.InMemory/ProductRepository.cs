using System.Collections.Generic;
using System.Linq;
using Advertisement.Interfaces;
using Advertisement.Repositories.InMemory.Entities;
using Advertisement.Repositories.InMemory.Factories;

namespace Advertisement.Repositories.InMemory
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICollection<ProductEntity> _products;

        public ProductRepository()
        {
            _products = new List<ProductEntity>();
            Initialise();
        }

        public ICollection<ProductDto> GetProducts()
        {
            return _products.Select(ProductDtoFactory.Create).ToList();
        }

        private void Initialise()
        {
            InsertProduct("classic", "Classic Ad", 269.99);
            InsertProduct("standout", "Standout Ad", 322.99);
            InsertProduct("premium", "Premium Ad", 394.99);
        }

        private void InsertProduct(string productId, string productName, double price)
        {
            _products.Add(new ProductEntity
            {
                ProductId = productId,
                ProductName = productName,
                Price = price
            });
        }
    }
}