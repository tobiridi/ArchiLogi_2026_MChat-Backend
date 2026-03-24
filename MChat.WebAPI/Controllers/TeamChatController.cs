using MChat.Application.Features.GetUser.Queries;
using MChat.Application.Features.TeamChatting.Queries.GetOwnerTeamChats;
using MChat.Application.Features.TeamChatting.Queries.GetUserJoinedTeamChats;
using MChat.Application.Interfaces;
using MChat.Domain.Entities;
using MChat.Domain.Entities.TeamChatting;
using MChat.WebAPI.DTOs.Responses.TeamChatting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MChat.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class TeamChatController : ControllerBase
    {
        private readonly ITeamChatService _teamChatService;
        private readonly ITeamMemberService _teamMemberService;
        private readonly IUserService _userService;

        public TeamChatController(ITeamChatService teamChatService, IUserService userService, ITeamMemberService teamMemberService)
        {
            _teamChatService = teamChatService;
            _userService = userService;
            _teamMemberService = teamMemberService;
        }

        // GET: api/v1/TeamChat/user
        [HttpGet("user", Name = "user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserTeamChat()
        {
            string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid.TryParse(nameIdentifier, out Guid userId);

            GetOwnerTeamChatsQuery query = new GetOwnerTeamChatsQuery(userId);
            try
            {
                IEnumerable<TeamChat> teams = await _teamChatService.GetOwnerTeamChats(query);
                User? usr = await _userService.FindUserByIdAsync(new GetUserByIdQuery(userId));

                return Ok(new GetOwnerTeamChatResponse(teams, usr));
            }
            catch (Exception)
            {
                return Problem(detail: "An error occurred when retrieve the user team chats.", statusCode: StatusCodes.Status500InternalServerError);
            }

        }

        // GET: api/v1/TeamChat/user/joined
        [HttpGet("user/joined", Name = "userJoined")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserJoinedTeamChat()
        {
            string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Guid.TryParse(nameIdentifier, out Guid userId);

            GetUserJoinedTeamChatsQuery query = new GetUserJoinedTeamChatsQuery(userId);

            try
            {
                IEnumerable<TeamChat> teams = await _teamMemberService.GetUserJoinedTeamChat(query);
                return Ok(new GetUserJoinTeamChatResponse(teams));
            }
            catch (Exception)
            {
                return Problem(detail: "An error occurred when retrieve the user joined team chats.", statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
