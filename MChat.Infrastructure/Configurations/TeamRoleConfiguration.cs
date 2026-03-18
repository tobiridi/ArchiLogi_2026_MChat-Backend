using MChat.Domain.Entities.TeamChatting;
using MChat.Infrastructure.JoinEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Configurations
{
    internal class TeamRoleConfiguration : IEntityTypeConfiguration<TeamRole>
    {
        public void Configure(EntityTypeBuilder<TeamRole> builder)
        {
            builder.ToTable("TeamsRoles");

            builder.Property(tr => tr.TeamRoleName)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            //constraints
            builder.HasKey(tr => tr.TeamRoleName)
                .HasName("PK_TeamsRoles");

            //foreign keys
            builder.HasOne(tr => tr.Team)
                .WithMany(tc => tc.TeamRoles)
                .HasConstraintName("FK_TeamsRoles_Teams")
                .HasForeignKey("Id_Teams")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(tr => tr.Permissions)
                .WithMany()
                .UsingEntity<TeamRoleTeamRolePermission>(
                    r => r.HasOne<TeamRolePermission>().WithMany().HasForeignKey(r => r.PermissionName),
                    l => l.HasOne<TeamRole>().WithMany().HasForeignKey(l => l.TeamRoleName)
                );
        }
    }
}
