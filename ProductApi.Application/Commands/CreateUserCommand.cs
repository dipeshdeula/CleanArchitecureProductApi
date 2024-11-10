using MediatR;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Commands
{
    public record CreateUserCommand(UserEntity User) : IRequest<UserEntity>;
   
}
