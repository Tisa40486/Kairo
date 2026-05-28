using KairoApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KairoApi.Data.DbContexts
{
    public class BaseDbContext<TContext> : DbContext, IBaseDbContext where TContext : DbContext
    {
        public BaseDbContext(DbContextOptions<TContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public new EntityEntry<TModelDao> Entry<TModelDao>(TModelDao entry) where TModelDao : class, IModelDao
        {
            return base.Entry(entry);
        }
    }
}