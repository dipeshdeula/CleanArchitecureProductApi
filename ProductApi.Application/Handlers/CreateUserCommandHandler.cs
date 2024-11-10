using MediatR;
using ProductApi.Application.Commands;
using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Application.Handlers
{
   /* public class CreateUserCommandHandler(IUserService userService)
        : IRequestHandler<CreateUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await userService.AddUserAsync(request.User, cancellationToken);
        }
    }*/
}
