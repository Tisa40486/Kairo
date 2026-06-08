using KairoApi.Db.DbContexts;
using KairoApi.Db.Repository;

namespace KairoApi.Db.UnitOfWork
{
    public class KairoApiUnitOfWork : IKairoApiUnitOfWork
    {
        public IKairoApiDbContext Context { get; }

        public ITaskRepository TaskRepository { get; }
        public IUserRepository UserRepository { get; }
        public KairoApiUnitOfWork(
            IKairoApiDbContext context, 
            ITaskRepository taskRepository,
            IUserRepository userRepository)
        {
            Context = context;
            TaskRepository = taskRepository;
            UserRepository = userRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}