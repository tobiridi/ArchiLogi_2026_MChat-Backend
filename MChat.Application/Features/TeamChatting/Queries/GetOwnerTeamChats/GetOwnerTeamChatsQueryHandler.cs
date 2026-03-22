using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Interfaces;
using Tools.CQS.Queries;

namespace MChat.Application.Features.TeamChatting.Queries.GetOwnerTeamChats
{
    internal class GetOwnerTeamChatsQueryHandler : IQueryHandler<GetOwnerTeamChatsQuery, IEnumerable<TeamChat>>
    {
        private readonly ITeamChatRepository _teamChatRepository;

        public GetOwnerTeamChatsQueryHandler(ITeamChatRepository teamChatRepository)
        {
            _teamChatRepository = teamChatRepository;
        }

        public async Task<IEnumerable<TeamChat>> Handle(GetOwnerTeamChatsQuery query)
        {
            return await Task.Run(() => _teamChatRepository.GetOwnerTeamChats(query.OwnerId));
        }
    }
}
