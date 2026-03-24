using Tools.CQS.Queries;

namespace MChat.Application.Features.GetUser.Queries
{
    public class GetUserByIdQuery : IQueryDefinition
    {
        public Guid UserId { get; }

        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
