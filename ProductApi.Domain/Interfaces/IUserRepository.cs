using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> AuthenticateAsync(string username, string password);
        Task<UserEntity> GetByIdAsync(int id);
    }
}
