using MChat.Application.Features.Authentication.Commands.Register;
using MChat.Application.Interfaces;
using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Tools.CQS.Commands;

namespace MChat.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationService(IPasswordHasher<User> hasher, IUserRepository userRepository)
        {
            _passwordHasher = hasher;
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUser(RegisterCommand command)
        {
            string hashPwd = _passwordHasher.HashPassword(null!, command.Password);
            RegisterCommand commandPassword = new RegisterCommand(command.Email, hashPwd, command.Username);

            ICommandHandler<RegisterCommand> handler = new RegisterCommandHandler(_userRepository);
            return await handler.Handle(commandPassword);
        }
    }
}
