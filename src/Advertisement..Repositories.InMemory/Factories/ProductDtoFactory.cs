using Advertisement.Interfaces;
using Advertisement.Repositories.InMemory.Entities;

namespace Advertisement.Repositories.InMemory.Factories
{
    public class ProductDtoFactory
    {
        public static ProductDto Create(ProductEntity productEntity)
        {
            return new ProductDto

            {
                ProductId = productEntity.ProductId,
                ProductName = productEntity.ProductName,
                Price = productEntity.Price
            };
        }
    }
}