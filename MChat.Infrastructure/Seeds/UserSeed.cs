using MChat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            DateTime now = DateTime.UtcNow;

            User[] data = [
                new User(Guid.NewGuid(), null, "", "old member", DateOnly.FromDateTime(now), now),
            ];

            builder.HasData(data);
        }
    }
}
