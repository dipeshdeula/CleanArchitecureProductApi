using MediatR;
using ProductApi.Application.Commands;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,ProductEntity>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        
        }

        public async Task<ProductEntity> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (request.ProductImage != null && request.ProductImage.Length > 0)
            {
                //Generate a unique file name using Guid
                var fileName = Guid.NewGuid() + Path.GetExtension(request.ProductImage.FileName);
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                //check if the directory exists, if not, create it
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                
                }

                //combine the directory and file name to get the full file path
                var filePath = Path.Combine(directoryPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ProductImage.CopyToAsync(stream);
                }


                //set the image URL in the product
                request.ImageUrl = fileName;

            }

            var product = new ProductEntity
            { 
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ImageUrl = request.ImageUrl
            };

            return await _productService.CreateProductAsync(product);
        }
    }
}
