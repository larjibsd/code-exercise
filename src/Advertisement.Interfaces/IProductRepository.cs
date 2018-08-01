using System.Collections.Generic;

namespace Advertisement.Interfaces
{
    public interface IProductRepository
    {
        ICollection<ProductDto> GetProducts();
    }
}
