using MChat.Application.Features.TeamChatting.Queries.GetOwnerTeamChats;
using MChat.Application.Interfaces;
using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Interfaces;
using Tools.CQS.Queries;

namespace MChat.Application.Services
{
    public class TeamChatService : ITeamChatService
    {
        private readonly ITeamChatRepository _teamChatRepository;

        public TeamChatService(ITeamChatRepository teamChatRepository)
        {
            _teamChatRepository = teamChatRepository;
        }

        public async Task<IEnumerable<TeamChat>> GetOwnerTeamChats(GetOwnerTeamChatsQuery query)
        {
            IQueryHandler<GetOwnerTeamChatsQuery, IEnumerable<TeamChat>> handler = new GetOwnerTeamChatsQueryHandler(_teamChatRepository);
            return await handler.Handle(query);
        }
    }
}
