using MChat.Infrastructure.DatabaseContext;

namespace MChat.Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            this._context = context;
        }
    }
}
