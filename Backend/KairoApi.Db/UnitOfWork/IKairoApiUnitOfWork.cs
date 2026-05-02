using KairoApi.Db.DbContexts;
using KairoApi.Db.Repository;

namespace KairoApi.Db.UnitOfWork
{
    public interface IKairoApiUnitOfWork
    {
        IKairoApiDbContext Context { get; }
        ITaskRepository TaskRepository { get; }
        Task<int> SaveChangesAsync();
    }
}