using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using Tools.CQS.Queries;

namespace MChat.Application.Features.GetUser.Queries
{
    internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetUserByIdQuery query)
        {
            return await _userRepository.GetByIdAsync(query.UserId);
        }
    }
}
