using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using MChat.Infrastructure.DatabaseContext;

namespace MChat.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        { }

        public async Task<bool> RegisterAsync(User user)
        {
            await this._context.Users.AddAsync(user);
            int changes = await this._context.SaveChangesAsync();
            return changes > 0;
        }

    }
}
