using MediatR;
using Microsoft.AspNetCore.Http;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Commands
{
    public class CreateProductCommand : IRequest<ProductEntity>
    {
        public CreateProductCommand(string name, string description, decimal price, string ImageName, IFormFile productImage)
        {
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = ImageName;
            ProductImage = productImage;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile ProductImage { get; set; }

    }
}
