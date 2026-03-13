using MChat.Application.Features.Authentication.Commands.Register;
using MChat.Application.Features.Authentication.Commands.CreateUserRefreshToken;
using MChat.Application.Features.Authentication.Queries.Login;
using MChat.Domain.Entities;
using MChat.Application.Features.Authentication.Commands.DeleteUserRefreshToken;

namespace MChat.Application.Interfaces
{
    /// <summary>
    /// Regroup all actions to Authentication.
    /// </summary>
    /// <remarks>
    /// Provide actions and delegate the tasks of how the <strong>Application layer</strong> manage the communication with the <strong>Infrastructure layer</strong>.
    /// </remarks>
    public interface IAuthenticationService
    {
        public Task<bool> RegisterUser(RegisterCommand command);
        public Task<User?> LoginUser(LoginQuery query);
        public Task<bool> SaveUserRefreshToken(CreateUserRefreshTokenCommand command);
        public Task<bool> DeleteUserRefreshToken(DeleteUserRefreshTokenCommand command);
    }
}
