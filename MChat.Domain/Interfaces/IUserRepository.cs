using MChat.Domain.Entities;

namespace MChat.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> RegisterAsync(User user);
    }
}
