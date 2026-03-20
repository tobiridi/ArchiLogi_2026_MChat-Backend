using MChat.Domain.Entities.TeamChatting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Configurations
{
    internal class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.ToTable("TeamMembers");

            //constraints
            builder.HasKey(tm => new { tm.UserId, tm.TeamId, tm.TeamRoleId })
                .HasName("PK_TeamMembers");

            //foreign keys
            builder.HasOne(tm => tm.User)
                .WithMany(u => u.TeamMembers)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tm => tm.Team)
                .WithMany(tc => tc.TeamMembers)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(tm => tm.TeamRole)
                .WithMany(tr => tr.TeamMembers)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
