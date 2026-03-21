using MChat.Domain.Entities.TeamChatting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Configurations
{
    internal class TeamRolePermissionConfiguration : IEntityTypeConfiguration<TeamRolePermission>
    {
        public void Configure(EntityTypeBuilder<TeamRolePermission> builder)
        {
            builder.ToTable("TeamsRolesPermissions");

            builder.Property(trp => trp.PermissionName)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            //constraints
            builder.HasKey(trp => trp.PermissionName)
                .HasName("PK_TeamsRolesPermissions");
        }
    }
}
