using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Tools.CQS.Commands;

namespace MChat.Application.Features.Authentication.Commands.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterCommand command)
        {
            User registerUser = new User(command.Email, command.Password, command.Username);
            return await _userRepository.RegisterAsync(registerUser);
        }
    }
}
