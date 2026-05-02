using KairoApi.Data.Repository;
using KairoApi.Model;
using KairoApi.Db.DbContexts;


namespace KairoApi.Db.Repository.Implementation
{
    public class TaskRepository : BaseRepository<IKairoApiDbContext, TaskDao>, ITaskRepository
    {
        public TaskRepository(IKairoApiDbContext context) : base(context)
        {
        }
    }
}
