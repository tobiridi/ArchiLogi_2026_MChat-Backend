using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Interfaces;
using MChat.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MChat.Infrastructure.Repositories
{
    public class TeamChatRepository : BaseRepository, ITeamChatRepository
    {
        public TeamChatRepository(AppDbContext context) : base(context)
        {
        }

        public List<TeamChat> GetOwnerTeamChats(Guid userId)
        {
            return _context.Teams.Where(tc => tc.Creator.Id == userId)
                .ToList();
        }
    }
}
