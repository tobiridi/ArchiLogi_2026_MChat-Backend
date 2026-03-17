using MChat.Domain.Entities;

namespace MChat.Domain.Interfaces
{
    public interface ITeamChatRepository
    {
        Task<List<TeamChat>>GetOwnerTeamChatsAsync(Guid userId);
        Task<List<TeamChat>>GetJoinedTeamChatsAsync(Guid userId);
    }
}
