using ProductApi.Domain.Entities;
using ProductApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
        Task<ProductEntity> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductEntity product);
        Task UpdateProductAsync(ProductEntity product);
        Task DeleteProductAsync(int id);

        Task UploadFileAsync(ImageDetails imageDetails);


    }
}
