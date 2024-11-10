using Microsoft.EntityFrameworkCore;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Models;

namespace ProductApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<ImageDetails> ImageDetails { get; set; } = null!;
    }
}
