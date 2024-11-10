using MediatR;
using ProductApi.Application.Queries;
using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Handlers
{
    public class GetUserByIdQueryHandler(IUserService userService)
        : IRequestHandler<GetUserByIdQuery, UserEntity>
    {
        public async Task<UserEntity> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await userService.GetByIdAsync(request.UserId);
        }
    }
}
