using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using Tools.CQS.Queries;

namespace MChat.Application.Features.Authentication.Queries.Login
{
    internal class LoginQueryHandler : IQueryHandler<LoginQuery, User?>
    {
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(LoginQuery query)
        {
            return await _userRepository.GetByEmailAsync(query.Email);
        }
    }
}
