using MChat.Application.Features.TeamChatting.Queries.GetOwnerTeamChats;
using MChat.Domain.Entities.TeamChatting;

namespace MChat.Application.Interfaces
{
    public interface ITeamChatService
    {
        Task<IEnumerable<TeamChat>> GetOwnerTeamChats(GetOwnerTeamChatsQuery query);
    }
}
