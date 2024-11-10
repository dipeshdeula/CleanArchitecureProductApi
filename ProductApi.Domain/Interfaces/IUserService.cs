using ProductApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserEntity> AuthenticateAsync(string username, string password);
        Task<UserEntity> GetByIdAsync(int id);
        //Task<UserEntity> AddUserAsync(UserEntity User);
    }
}
