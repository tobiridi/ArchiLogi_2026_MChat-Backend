using Tools.CQS.Queries;

namespace MChat.Application.Features.TeamChatting.Queries.GetOwnerTeamChats
{
    public class GetOwnerTeamChatsQuery : IQueryDefinition
    {
        public Guid OwnerId { get; }

        public GetOwnerTeamChatsQuery(Guid ownerId)
        {
            OwnerId = ownerId;
        }
    }
}
