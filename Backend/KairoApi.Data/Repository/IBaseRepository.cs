using KairoApi.Data.DbContexts;
using KairoApi.Data.Model;

namespace KairoApi.Data.Repository
{
    public interface IBaseRepository<TContext, TModelDao>
        where TModelDao : class, IModelDao
        where TContext : IBaseDbContext
    {
        TContext _context { get; }
        Task<IEnumerable<TModelDao>> GetAllAsync(bool withNoTracking = true);
        Task<TModelDao?> GetByIdAsync(int id, bool withNoTracking = true);

        Task AddAndSaveAsync(TModelDao entity);
        Task UpdateAsync(TModelDao entity);
        Task RemoveAsync(TModelDao entity);
        Task RemoveByIdAsync(int id, bool withNoTracking = true);

    }
}