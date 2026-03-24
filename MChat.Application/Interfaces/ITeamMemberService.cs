using MChat.Application.Features.TeamChatting.Queries.GetUserJoinedTeamChats;
using MChat.Domain.Entities.TeamChatting;

namespace MChat.Application.Interfaces
{
    public interface ITeamMemberService
    {
        Task<IEnumerable<TeamChat>> GetUserJoinedTeamChat(GetUserJoinedTeamChatsQuery query);
    }
}
