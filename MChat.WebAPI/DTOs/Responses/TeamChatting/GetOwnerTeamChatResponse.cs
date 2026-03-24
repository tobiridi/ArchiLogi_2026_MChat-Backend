using MChat.Domain.Entities;
using MChat.Domain.Entities.TeamChatting;
using Microsoft.EntityFrameworkCore;

namespace MChat.WebAPI.DTOs.Responses.TeamChatting
{
    public class GetOwnerTeamChatResponse
    {
        public IEnumerable<TeamChat> Teams { get; init; }
        public User? Creator { get; init; }

        public GetOwnerTeamChatResponse(IEnumerable<TeamChat> teams, User? creator)
        {
            if(creator is null)
            {
                Teams = [];
                Creator = creator;
            }
            else
            {
                Teams = teams.Select(tc => new TeamChat()
                {
                    Id = tc.Id,
                    TeamName = tc.TeamName,
                    CoverImageUrl = tc.CoverImageUrl,
                });

                Creator = new User()
                {
                    Id = creator.Id,
                    Username = creator.Username
                };
            }
        }
    }
}
