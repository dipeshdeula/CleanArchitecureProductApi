using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public UpdateProductCommand(int id, string name, string descripiton, decimal price, IFormFile productImage)
        {
            Id = id;
            Name = name;
            Description = descripiton;
            Price = price;
            ProductImage = productImage;

        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public IFormFile? ProductImage { get; set; }
    }
}
