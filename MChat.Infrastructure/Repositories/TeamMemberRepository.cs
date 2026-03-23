using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Interfaces;
using MChat.Infrastructure.DatabaseContext;

namespace MChat.Infrastructure.Repositories
{
    public class TeamMemberRepository : BaseRepository, ITeamMemberRepository
    {
        public TeamMemberRepository(AppDbContext context) : base(context)
        {
        }

        public List<TeamChat> GetJoinedTeamChats(Guid userId)
        {
            return _context.TeamsMembers
                .Where(tm => tm.UserId == userId)
                .Select(tm => tm.Team)
                .ToList();
        }
    }
}
