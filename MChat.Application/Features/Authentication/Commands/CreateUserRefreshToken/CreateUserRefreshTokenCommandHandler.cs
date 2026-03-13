using MChat.Domain.Interfaces;
using Tools.CQS.Commands;

namespace MChat.Application.Features.Authentication.Commands.CreateUserRefreshToken
{
    internal class CreateUserRefreshTokenCommandHandler : ICommandHandler<CreateUserRefreshTokenCommand>
    {
        private readonly IAuthRepository _authRepository;

        public CreateUserRefreshTokenCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<bool> Handle(CreateUserRefreshTokenCommand command)
        {
            await _authRepository.SaveUserRefreshTokenAsync(command.RefreshTokenEntity);
            return true;
        }
    }
}
