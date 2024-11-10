using MediatR;
using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Queries
{
    public record GetProductByIdQuery(int Id):IRequest<ProductEntity>;
   
}
