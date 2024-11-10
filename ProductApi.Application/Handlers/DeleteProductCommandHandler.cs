using MediatR;
using ProductApi.Application.Commands;
using ProductApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,int>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductAsync(request.Id);
            return request.Id;
        }
    }
}
