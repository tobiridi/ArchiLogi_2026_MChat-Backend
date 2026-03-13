using MChat.Domain.Entities;

namespace MChat.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<bool> RegisterAsync(User user);
        Task SaveUserRefreshTokenAsync(JwtRefreshTokenUser entity);
        Task<bool> DeleteUserRefreshTokenAsync(Guid userId);
    }
}
