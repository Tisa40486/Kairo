using KairoApi.Db.DbContexts;
using KairoApi.Db.Repository;

namespace KairoApi.Db.UnitOfWork
{
    public class KairoApiUnitOfWork : IKairoApiUnitOfWork
    {
        public IKairoApiDbContext Context { get; }

        public ITaskRepository TaskRepository { get; }
        public IStatusRepository StatusRepository { get; }
        public KairoApiUnitOfWork(
            IKairoApiDbContext context, 
            ITaskRepository userRepository,
            IStatusRepository statusRepository)
        {
            Context = context;
            TaskRepository = userRepository;
            StatusRepository = statusRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}