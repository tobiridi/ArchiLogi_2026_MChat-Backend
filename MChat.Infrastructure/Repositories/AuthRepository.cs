using MChat.Domain.Entities;
using MChat.Domain.Interfaces;
using MChat.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace MChat.Infrastructure.Repositories
{
    public class AuthRepository : BaseRepository, IAuthRepository
    {
        public AuthRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> RegisterAsync(User user)
        {
            await this._context.Users.AddAsync(user);
            int changes = await this._context.SaveChangesAsync();
            return changes > 0;
        }

        public async Task SaveUserRefreshTokenAsync(JwtRefreshTokenUser entity)
        {
            JwtRefreshTokenUser? existingToken = await this._context.JwtTokenUsers
                                                .Where(tk => tk.User.Equals(entity.User))
                                                .SingleOrDefaultAsync();

            if (existingToken is not null)
            {
                //if the user already have a refresh token, replace it
                this._context.JwtTokenUsers.Remove(existingToken);
            }

            await this._context.JwtTokenUsers.AddAsync(entity);
            await this._context.SaveChangesAsync();
            return;
        }
    }
}
