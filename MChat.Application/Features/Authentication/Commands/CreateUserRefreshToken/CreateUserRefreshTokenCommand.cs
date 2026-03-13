using MChat.Domain.Entities;
using Tools.CQS.Commands;

namespace MChat.Application.Features.Authentication.Commands.CreateUserRefreshToken
{
    public class CreateUserRefreshTokenCommand : ICommandDefinition
    {
        public JwtRefreshTokenUser RefreshTokenEntity { get; }

        public CreateUserRefreshTokenCommand(JwtRefreshTokenUser refreshTokenEntity)
        {
            this.RefreshTokenEntity = refreshTokenEntity;
        }
    }
}
