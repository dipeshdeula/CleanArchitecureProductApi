using MediatR;
using ProductApi.Application.Queries;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductEntity>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProductsAsync();
        }
    }

}
