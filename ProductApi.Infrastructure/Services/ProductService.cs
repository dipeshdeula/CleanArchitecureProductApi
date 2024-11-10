
using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;
using ProductApi.Domain.Models;

namespace ProductApi.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<ProductEntity> GetProductByIdAsync(int id)
        {

            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<ProductEntity> CreateProductAsync(ProductEntity product)
        {
            await _productRepository.AddProductAsync(product);
            return product;
        }
        public async Task UpdateProductAsync(ProductEntity product)
        {
            await _productRepository.UpdateProductAsync(product);
        }
        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task UploadFileAsync(ImageDetails imageDetail)
        {
            await _productRepository.UploadFileAsync(imageDetail);
        }
    }
}
