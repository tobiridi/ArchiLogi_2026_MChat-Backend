using MChat.Domain.Entities.TeamChatting;

namespace MChat.WebAPI.DTOs.Responses.TeamChatting
{
    public class GetUserJoinTeamChatResponse
    {
        public IEnumerable<TeamChat> Teams { get; init; }

        public GetUserJoinTeamChatResponse(IEnumerable<TeamChat> teams)
        {
            Teams = teams;
        }
    }
}
