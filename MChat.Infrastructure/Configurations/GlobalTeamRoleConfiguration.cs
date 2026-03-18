using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Configurations
{
    internal class GlobalTeamRoleConfiguration : IEntityTypeConfiguration<GlobalTeamRole>
    {
        public void Configure(EntityTypeBuilder<GlobalTeamRole> builder)
        {
            builder.ToTable("Global_Teams_Roles");

            builder.Property(gtr => gtr.GlobalRoleName)
                .HasColumnName("global_role_name")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .HasConversion(
                    enumVal => enumVal.ToString().ToLowerInvariant(),
                    stringVal => (GlobalTeamRoleName)Enum.Parse(typeof(GlobalTeamRoleName), stringVal, true)
                );

            //constraints
            builder.HasKey(gtr => gtr.GlobalRoleName)
                .HasName("PK_Global_Teams_Roles");

            //foreign key
            builder.HasMany(gtr => gtr.Permissions)
                .WithMany();
        }
    }
}
