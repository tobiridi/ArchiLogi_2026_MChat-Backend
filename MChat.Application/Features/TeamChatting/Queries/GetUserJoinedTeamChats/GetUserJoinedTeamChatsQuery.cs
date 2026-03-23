using Tools.CQS.Queries;

namespace MChat.Application.Features.TeamChatting.Queries.GetUserJoinedTeamChats
{
    public class GetUserJoinedTeamChatsQuery : IQueryDefinition
    {
        public Guid userId { get; }

        public GetUserJoinedTeamChatsQuery(Guid userId)
        {
            this.userId = userId;
        }
    }
}
