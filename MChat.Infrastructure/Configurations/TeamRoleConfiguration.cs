using MChat.Domain.Entities.TeamChatting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Configurations
{
    internal class TeamRoleConfiguration /*: IEntityTypeConfiguration<TeamRole>*/
    {
        //public void Configure(EntityTypeBuilder<TeamRole> builder)
        //{
        //    builder.ToTable("Teams_Roles");

        //    builder.Property(tr => tr.RoleName)
        //        .HasColumnType("nvarchar")
        //        .HasMaxLength(100)
        //        .IsRequired();

        //    //constraints
        //    builder.HasKey(tr => tr.RoleName)
        //        .HasName("PK_Teams_Roles");
        //}
    }
}
