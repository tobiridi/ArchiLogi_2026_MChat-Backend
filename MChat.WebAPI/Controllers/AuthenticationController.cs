using MChat.Application.Features.Authentication.Commands.DeleteUserRefreshToken;
using MChat.Application.Features.Authentication.Commands.Register;
using MChat.Application.Features.Authentication.Commands.CreateUserRefreshToken;
using MChat.Application.Features.Authentication.Queries.Login;
using MChat.Application.Interfaces;
using MChat.Domain.Entities;
using MChat.WebAPI.DTOs.Requests.Authentication;
using MChat.WebAPI.DTOs.Responses.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

namespace MChat.WebAPI.Controllers
{
    [Route("/api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthenticationController(IAuthenticationService authenticationService, IJwtTokenService jwtTokenService)
        {
            _authenticationService = authenticationService;
            _jwtTokenService = jwtTokenService;
        }

        // POST: api/v1/Authentication/register
        [HttpPost("register", Name = "register")]
        [EnableRateLimiting("Authentication")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(AuthenticateRequest request)
        {
            RegisterCommand command = new RegisterCommand(request.Email, request.Password, request.Username);
            try
            {
                bool isRegister = await _authenticationService.RegisterUser(command);
                if (isRegister)
                    return Created();
                else
                    return Problem(detail: "Can not register the user.", statusCode: StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return Problem(detail: "An error occurred when register the user.", statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // POST: api/v1/Authentication/login
        [HttpPost("login", Name = "login")]
        [EnableRateLimiting("Authentication")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginQuery query = new LoginQuery(request.Email, request.Password);
            User? user = null;

            try
            {
                user = await _authenticationService.LoginUser(query);
            }
            catch (Exception)
            {
                return Problem(detail: "An error occurred when login the user.", statusCode: StatusCodes.Status500InternalServerError);
            }

            if(user is null)
            {
                return BadRequest("Credentials are invalid.");
            }

            string jwtToken = _jwtTokenService.GenerateAccess(user);
            JwtRefreshTokenUser jwtRefreshToken = _jwtTokenService.GenerateRefresh(user);

            try
            {
                CreateUserRefreshTokenCommand command = new CreateUserRefreshTokenCommand(jwtRefreshToken);
                await _authenticationService.SaveUserRefreshToken(command);
            }
            catch (Exception)
            {
                return Problem(detail: "An error occurred when saving the refresh token of the user.", statusCode: StatusCodes.Status500InternalServerError);
            }

            LoginResponse response = new LoginResponse(jwtToken, jwtRefreshToken.RefreshToken);
            return Ok(response);
        }

        // DELETE: api/v1/Authentication/logout
        [HttpDelete("logout", Name = "logout")]
        [EnableRateLimiting("Authentication")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Logout()
        {
            if(User.Identity?.IsAuthenticated == true)
            {
                string? nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if(Guid.TryParse(nameIdentifier, out Guid userId))
                {
                    try
                    {
                        DeleteUserRefreshTokenCommand command = new DeleteUserRefreshTokenCommand(userId);
                        await _authenticationService.DeleteUserRefreshToken(command);
                    }
                    catch (Exception)
                    {
                        return Problem(detail: "An error occurred when saving the logout the user.", statusCode: StatusCodes.Status500InternalServerError);
                    }
                }
            }

            return NoContent();
        }
    }
}
