using MChat.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Configurations
{
    internal class TeamRolePermissionConfiguration : IEntityTypeConfiguration<TeamRolePermission>
    {
        public void Configure(EntityTypeBuilder<TeamRolePermission> builder)
        {
            builder.ToTable("Teams_Roles_Permissions");

            builder.Property(trp => trp.PermissionName)
                .HasColumnName("perm_name")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            //constraints
            builder.HasKey(trp => trp.PermissionName)
                .HasName("PK_Teams_Roles_Permissions");
        }
    }
}
