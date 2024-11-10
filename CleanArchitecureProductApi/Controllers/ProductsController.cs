using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.Commands;
using ProductApi.Application.DTOs;
using ProductApi.Application.Queries;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;

namespace CleanArchitecureProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductsController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await _mediator.Send(new GetAllProductQuery());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] ProductDto product, IFormFile productImage)
        {
            var createdProduct = await _mediator.Send(new CreateProductCommand(
                product.Name, product.Description, product.Price, null, productImage));

            //Generate the image URL
            var imageUrl = Url.Action("GetImages", "Products", new { fileName = createdProduct.ImageUrl }, Request.Scheme);

            // Return product details along with the image URL
            return Ok(new
            {
                createdProduct.Id,
                createdProduct.Name,
                createdProduct.Description,
                createdProduct.Price,
                ImageUrl = imageUrl
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductDto product, IFormFile? productImage)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var productReturn = await _mediator.Send(new UpdateProductCommand(
                id,
                product.Name,
                product.Description,
                product.Price,
                productImage));

            return Ok(productReturn);
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteProduct(int id)
        {
            return await _mediator.Send(new DeleteProductCommand { Id = id });
        }

    }
}
