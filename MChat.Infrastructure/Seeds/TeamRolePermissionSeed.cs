using MChat.Domain.Entities.TeamChatting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Seeds
{
    internal class TeamRolePermissionSeed : IEntityTypeConfiguration<TeamRolePermission>
    {
        public void Configure(EntityTypeBuilder<TeamRolePermission> builder)
        {
            var data = typeof(TeamRolePermission).GetFields()
                .Where(f => f.IsPublic && f.IsStatic && f.FieldType == typeof(TeamRolePermission))
                .Select(f => f.GetValue(null))
                .Cast<TeamRolePermission> ();

            builder.HasData(data);
        }
    }
}
