using Microsoft.EntityFrameworkCore;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;
using ProductApi.Domain.Models;
using ProductApi.Infrastructure.Data;

namespace ProductApi.Infrastructure.Repositories
{
    class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
           return await _context.Products.ToListAsync();
        }

        public async Task<ProductEntity> GetProductByIdAsync(int id)
        {
            var product =  await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            return product;
        }


        public async Task AddProductAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(ProductEntity product)
        {
            var productDetail = await _context.Products.FindAsync(product.Id);
            if (productDetail == null)
            { 
                throw new KeyNotFoundException("Product not found");

            }
            productDetail.Name = product.Name;
            productDetail.Description = product.Description;
            productDetail.Price = product.Price;

            await _context.SaveChangesAsync();

        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            { 
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

       
        

        public async Task UploadFileAsync(ImageDetails imageDetails)
        {

            await _context.ImageDetails.AddAsync(imageDetails);
            await _context.SaveChangesAsync();
        }
    }
}
