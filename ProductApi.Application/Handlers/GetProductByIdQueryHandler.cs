using MediatR;
using ProductApi.Application.Queries;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;

namespace ProductApi.Application.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductEntity>

    {
        private readonly IProductService _productService;
        public GetProductByIdQueryHandler(IProductService productService)
        {
            _productService = productService;

        }
        public async Task<ProductEntity> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductByIdAsync(request.Id);
        }
    }
}
