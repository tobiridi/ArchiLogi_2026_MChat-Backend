using MChat.Domain.Entities;
using MChat.Infrastructure.Configurations;
using MChat.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace MChat.Infrastructure.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserSeed());
        }
    }
}
