﻿using MediatR;
using ProductApi.Application.Commands;
using ProductApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand,int>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(request.Id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            if (request.ProductImage != null && request.ProductImage.Length > 0)
            {
                //Generate a unique file name using Guid
                var fileName = Guid.NewGuid() + Path.GetExtension(request.ProductImage.FileName);
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                //check if the directory exists, if not , create it
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

                //set the image Url in the product
                product.ImageUrl = fileName;
            }

            product.Id = request.Id;
            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

            await _productService.UpdateProductAsync(product);
            return product.Id;
        }
    }
}
