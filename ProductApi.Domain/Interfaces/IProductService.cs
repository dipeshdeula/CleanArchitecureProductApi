using ProductApi.Domain.Entities;
using ProductApi.Domain.Models;

namespace ProductApi.Domain.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
        Task<ProductEntity> GetProductByIdAsync(int id);
        Task<ProductEntity> CreateProductAsync(ProductEntity product);
        Task UpdateProductAsync(ProductEntity product);
        Task DeleteProductAsync(int id);

        Task UploadFileAsync(ImageDetails imageDetail);
    }
}
