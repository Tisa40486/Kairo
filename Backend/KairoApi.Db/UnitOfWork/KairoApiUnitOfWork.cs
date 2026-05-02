using KairoApi.Db.DbContexts;
using KairoApi.Db.Repository;

namespace KairoApi.Db.UnitOfWork
{
    public class KairoApiUnitOfWork : IKairoApiUnitOfWork
    {
        public IKairoApiDbContext Context { get; }

        public ITaskRepository TaskRepository { get; }
        public KairoApiUnitOfWork(IKairoApiDbContext context, ITaskRepository userRepository)
        {
            Context = context;
            TaskRepository = userRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}