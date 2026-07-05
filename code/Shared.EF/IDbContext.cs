using Microsoft.EntityFrameworkCore;

namespace Shared.EF
{
    public interface IDbContext
    {
        DbSet<T> DbSet<T>() where T : class;
    }

    internal class DBContext(EFContext context) : IDbContext
    {
        private readonly EFContext _context = context;
        public DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();
        }
    }

    public interface IQueryContext
    {
        DbSet<T> DbSet<T>() where T : class;
    }

    internal class QueryContext(ReadOnlyContext context) : IQueryContext
    {
        private readonly ReadOnlyContext _context = context;
        public DbSet<T> DbSet<T>() where T : class
        {
            return _context.Set<T>();
        }
    }
}
