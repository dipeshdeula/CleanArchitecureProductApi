using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserEntity> AuthenticateAsync(string username, string password)
        {
            return await _userRepository.AuthenticateAsync(username, password);
        }

        public async Task<UserEntity> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }
    }
}
