using MChat.Domain.Entities;
using MChat.Domain.Entities.TeamChatting;

namespace MChat.Domain.Interfaces
{
    public interface ITeamChatRepository
    {
        List<TeamChat> GetOwnerTeamChats(Guid userId);
    }
}
