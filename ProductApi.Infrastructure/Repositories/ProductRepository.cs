using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;
using ProductApi.Domain.Models;
using ProductApi.Infrastructure.Data;
using System.Data;

namespace ProductApi.Infrastructure.Repositories
{
   public class ProductRepository : IProductRepository
    {
        //Implement through Dapper
        private readonly ApplicationDbContext _context;

        private readonly IConfiguration configuration;
        private readonly string _connectionString;

        public ProductRepository(ApplicationDbContext context,IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            //return await _context.Products.ToListAsync();
            //change for using Dapper
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "SE");

                return await connection.QueryAsync<ProductEntity>(
                    "[SP_Product]",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<ProductEntity> GetProductByIdAsync(int productId)
        {
            /*var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            return product;*/

            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "SE");
                parameters.Add("@ProductID", productId);

                return await connection.QueryFirstOrDefaultAsync<ProductEntity>("SP_Products",
                    parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<string> AddProductAsync(ProductEntity product)
        {
            /* await _context.Products.AddAsync(product);
             await _context.SaveChangesAsync();*/

            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "I");
                parameters.Add("@ProductID", product.Id);
                parameters.Add("@Name", product.Name);
                parameters.Add("@Description", product.Description);
                parameters.Add("@Price", product.Price);
                parameters.Add("@ImageUrl", product.ImageUrl);

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                     "[SP_Product]",
                     parameters,
                     commandType: CommandType.StoredProcedure);

                return result?.Msg ?? "Operation failed.";
            }
        }

        public async Task<string> UpdateProductAsync(ProductEntity product)
        {
            /* var productDetail = await _context.Products.FindAsync(product.Id);
             if (productDetail == null)
             {
                 throw new KeyNotFoundException("Product not found");

             }
             productDetail.Name = product.Name;
             productDetail.Description = product.Description;
             productDetail.Price = product.Price;

             await _context.SaveChangesAsync();
             */

            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "U");
                parameters.Add("@ProductID", product.Id);
                parameters.Add("@Name", product.Name);
                parameters.Add("@Description", product.Description);
                parameters.Add("@Price", product.Price);
                parameters.Add("@ImageUrl", product.ImageUrl);

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                    "[SP_Product]",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result?.Msg ?? "Operation failed.";
            }
        }

        public async Task<String> DeleteProductAsync(int productId)
        {
            /*var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }*/

            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "D");
                parameters.Add("@ProductID", productId);

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                        "[SP_Product]",
                        parameters,
                        commandType: CommandType.StoredProcedure);

                return result?.Msg ?? "Operation failed.";
            }


        }




        public async Task UploadFileAsync(ImageDetails imageDetails)
        {

            await _context.ImageDetails.AddAsync(imageDetails);
            await _context.SaveChangesAsync();

            /*using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "I");
                parameters.Add("@ProductID", imageDetails.ProductId);
                parameters.Add("@ImageName", imageDetails.ImageName);
                parameters.Add("@ImageUrl", imageDetails.ImageUrl);

                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(
                    "SP_ImageDetails",
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return result?.Msg ?? "Operation failed.";
            }*/
        }
    }
}
