using KairoApi.Data.Repository;
using KairoApi.Db.DbContexts;
using KairoApi.Model;
using KairoApi.Model.LKP;
using Microsoft.EntityFrameworkCore;


namespace KairoApi.Db.Repository.Implementation
{
    public class TaskRepository : BaseRepository<IKairoApiDbContext, TaskDao>, ITaskRepository
    {
        private readonly IKairoApiDbContext _kairoApiDbContext;
        public TaskRepository(IKairoApiDbContext context) : base(context)
        {
            _kairoApiDbContext = context;

        }
    }
}