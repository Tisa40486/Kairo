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
        public async override Task AddAndSaveAsync(TaskDao entity)
        {
            var status = await _kairoApiDbContext.Set<LKP_StatusDao>()
                .FirstOrDefaultAsync(s => s.Id == entity.StatusDaoId);

            if (status == null)
                throw new Exception("Status introuvable");

            entity.LKP_StatusDao = status;

            await base.AddAndSaveAsync(entity);
        }
    }
}