using Microsoft.EntityFrameworkCore;
using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Data;

namespace ProductApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserEntity> AuthenticateAsync(string username, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public async Task<UserEntity> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}
