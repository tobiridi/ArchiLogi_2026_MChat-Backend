using MChat.Domain.Entities.TeamChatting;

namespace MChat.Domain.Interfaces
{
    public interface ITeamMemberRepository
    {
        List<TeamChat> GetJoinedTeamChats(Guid userId);
    }
}
