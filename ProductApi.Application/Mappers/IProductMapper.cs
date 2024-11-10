using ProductApi.Application.DTOs;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Mappers
{
    public interface IProductMapper
    {
        ProductDto MapToDto(ProductEntity product);
        ProductEntity MapToEntity(ProductDto productDto);
    }
}
