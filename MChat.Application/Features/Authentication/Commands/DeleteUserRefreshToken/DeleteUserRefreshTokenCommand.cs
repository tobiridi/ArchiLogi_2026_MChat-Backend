using Tools.CQS.Commands;

namespace MChat.Application.Features.Authentication.Commands.DeleteUserRefreshToken
{
    public class DeleteUserRefreshTokenCommand : ICommandDefinition
    {
        public Guid userId { get; }

        public DeleteUserRefreshTokenCommand(Guid userId)
        {
            this.userId = userId;
        }
    }
}
