using ProductApi.Application.DTOs;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Mappers
{
    public interface ProductMapper
    {
        public ProductDto MapToDto(ProductEntity product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                //ImageUrl = product.ImageUrl
            };
        }

        public ProductEntity MapToEntity(ProductDto productDto)
        {
            return new ProductEntity
            {

                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                // ImageUrl = productDto.ImageUrl

            };
        }
    }
}
