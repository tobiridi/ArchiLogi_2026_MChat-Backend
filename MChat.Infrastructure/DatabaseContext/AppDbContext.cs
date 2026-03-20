using MChat.Domain.Entities;
using MChat.Domain.Entities.TeamChatting;
using MChat.Infrastructure.Configurations;
using MChat.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace MChat.Infrastructure.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<JwtRefreshTokenUser> JwtTokenUsers { get; set; }
        public DbSet<TeamChat> Teams { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new JwtRefreshTokenUserConfiguration());
            modelBuilder.ApplyConfiguration(new TeamChatConfiguration());
            modelBuilder.ApplyConfiguration(new TeamRolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new TeamRoleConfiguration());
            modelBuilder.ApplyConfiguration(new TeamMemberConfiguration());

            //seeds
            //modelBuilder.ApplyConfiguration(new UserSeed());
            //modelBuilder.ApplyConfiguration(new TeamRolePermissionSeed());

        }
    }
}
