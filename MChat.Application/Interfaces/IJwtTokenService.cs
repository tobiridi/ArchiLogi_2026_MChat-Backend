using MChat.Domain.Entities;

namespace MChat.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateAccess(User user);
        string GenerateRefresh();
    }
}
