using MChat.Application.Features.GetUser.Queries;
using MChat.Application.Interfaces;
using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using Tools.CQS.Queries;

namespace MChat.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> FindUserByIdAsync(GetUserByIdQuery query)
        {
            IQueryHandler<GetUserByIdQuery, User?> handler = new GetUserByIdQueryHandler(_userRepository);
            return await handler.Handle(query);
        }
    }
}
