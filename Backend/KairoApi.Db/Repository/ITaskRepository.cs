using KairoApi.Data.Repository;
using KairoApi.Db.DbContexts;
using KairoApi.Model;

namespace KairoApi.Db.Repository
{
    public interface ITaskRepository : IBaseRepository<IKairoApiDbContext, TaskDao>    
    {
    }
}
