using MChat.Domain.Entities.TeamChatting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Seeds
{
    internal class GlobalTeamRoleSeed : IEntityTypeConfiguration<GlobalTeamRole>
    {
        public void Configure(EntityTypeBuilder<GlobalTeamRole> builder)
        {
            GlobalTeamRole[] data = [
                new GlobalTeamRole(Domain.Enums.GlobalTeamRoleName.Owner, null),
                new GlobalTeamRole(Domain.Enums.GlobalTeamRoleName.Moderator, null),
                new GlobalTeamRole(Domain.Enums.GlobalTeamRoleName.Member, null),
            ];

            builder.HasData(data);
        }
    }
}
