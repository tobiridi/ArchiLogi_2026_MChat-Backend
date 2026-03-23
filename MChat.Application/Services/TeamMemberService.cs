using MChat.Application.Features.TeamChatting.Queries.GetUserJoinedTeamChats;
using MChat.Application.Interfaces;
using MChat.Domain.Entities.TeamChatting;
using MChat.Domain.Interfaces;
using Tools.CQS.Queries;

namespace MChat.Application.Services
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository)
        {
            _teamMemberRepository = teamMemberRepository;
        }

        public async Task<IEnumerable<TeamChat>> GetUserJoinedTeamChat(GetUserJoinedTeamChatsQuery query)
        {
            IQueryHandler<GetUserJoinedTeamChatsQuery, IEnumerable<TeamChat>> handler = new GetUserJoinedTeamChatsQueryHandler(_teamMemberRepository);
            return await handler.Handle(query);
        }
    }
}
