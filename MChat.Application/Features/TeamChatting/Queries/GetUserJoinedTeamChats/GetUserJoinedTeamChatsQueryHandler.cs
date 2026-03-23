using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Interfaces;
using Tools.CQS.Queries;

namespace MChat.Application.Features.TeamChatting.Queries.GetUserJoinedTeamChats
{
    internal class GetUserJoinedTeamChatsQueryHandler : IQueryHandler<GetUserJoinedTeamChatsQuery, IEnumerable<TeamChat>>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public GetUserJoinedTeamChatsQueryHandler(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public async Task<IEnumerable<TeamChat>> Handle(GetUserJoinedTeamChatsQuery query)
        {
            return await Task.Run(() => _teamMemberRepository.GetJoinedTeamChats(query.userId));
        }
    }
}
