using MChat.Domain.Interfaces;
using Tools.CQS.Commands;

namespace MChat.Application.Features.Authentication.Commands.DeleteUserRefreshToken
{
    internal class DeleteUserRefreshTokenCommandHandler : ICommandHandler<DeleteUserRefreshTokenCommand>
    {
        private readonly IAuthRepository _authRepository;

        public DeleteUserRefreshTokenCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<bool> Handle(DeleteUserRefreshTokenCommand command)
        {
            return await _authRepository.DeleteUserRefreshTokenAsync(command.userId);
        }
    }
}
