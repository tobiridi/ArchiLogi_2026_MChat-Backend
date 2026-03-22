using MChat.Application.Features.GetUser.Queries;
using MChat.Domain.Entities;

namespace MChat.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> FindUserByIdAsync(GetUserByIdQuery query);
    }
}
