using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using Tools.CQS.Commands;

namespace MChat.Application.Features.Authentication.Commands.Register
{
    internal class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IAuthRepository _authRepository;

        public RegisterCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<bool> Handle(RegisterCommand command)
        {
            User registerUser = new User(command.Email, command.Password, command.Username);
            return await _authRepository.RegisterAsync(registerUser);
        }
    }
}
