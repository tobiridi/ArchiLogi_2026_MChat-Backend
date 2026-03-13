using MChat.Application.Features.Authentication.Commands.Register;
using MChat.Application.Features.Authentication.Commands.CreateUserRefreshToken;
using MChat.Application.Features.Authentication.Queries.Login;
using MChat.Application.Interfaces;
using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Tools.CQS.Commands;
using Tools.CQS.Queries;
using MChat.Application.Features.Authentication.Commands.DeleteUserRefreshToken;

namespace MChat.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationService(IPasswordHasher<User> hasher, IUserRepository userRepository, IAuthRepository authRepository)
        {
            _passwordHasher = hasher;
            _userRepository = userRepository;
            _authRepository = authRepository;
        }

        public async Task<bool> DeleteUserRefreshToken(DeleteUserRefreshTokenCommand command)
        {
            ICommandHandler<DeleteUserRefreshTokenCommand> handler = new DeleteUserRefreshTokenCommandHandler(_authRepository);
            return await handler.Handle(command);
        }

        public async Task<User?> LoginUser(LoginQuery query)
        {
            IQueryHandler<LoginQuery, User?> handler = new LoginQueryHandler(_userRepository);
            User? user = await handler.Handle(query);

            if (user is not null)
            {
                PasswordVerificationResult resultPwd = _passwordHasher.VerifyHashedPassword(user, user.Password, query.Password);
                if(resultPwd == PasswordVerificationResult.Success)
                {
                    return user;
                }
            }

            return null;
        }

        public async Task<bool> RegisterUser(RegisterCommand command)
        {
            string hashPwd = _passwordHasher.HashPassword(null!, command.Password);
            RegisterCommand commandPassword = new RegisterCommand(command.Email, hashPwd, command.Username);

            ICommandHandler<RegisterCommand> handler = new RegisterCommandHandler(_authRepository);
            return await handler.Handle(commandPassword);
        }

        public async Task<bool> SaveUserRefreshToken(CreateUserRefreshTokenCommand command)
        {
            ICommandHandler<CreateUserRefreshTokenCommand> handler = new CreateUserRefreshTokenCommandHandler(_authRepository);
            return await handler.Handle(command);
        }
    }
}
