using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MChat.Infrastructure.Seeds
{
    internal class TeamRoleSeed : IEntityTypeConfiguration<TeamRole>
    {
        public void Configure(EntityTypeBuilder<TeamRole> builder)
        {
            GlobalTeamRoleName[] names = Enum.GetValues<GlobalTeamRoleName>();
            var data = new List<TeamRole>(names.Length);

            foreach (var name in names)
            {
                data.Add(new TeamRole(Guid.NewGuid(), name.ToString(), null!, null, null!));
            }

            builder.HasData(data);
        }
    }
}
