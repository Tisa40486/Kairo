using KairoApi.Data.Repository;
using KairoApi.Db.DbContexts;
using KairoApi.Model.LKP;

namespace KairoApi.Db.Repository.Implementation
{
    public class StatusRepository : BaseRepository<IKairoApiDbContext, LKP_StatusDao>, IStatusRepository
    {
        public StatusRepository(IKairoApiDbContext context) : base(context)
        {
        }
    }
}