using KairoApi.Data.Repository;
using KairoApi.Db.DbContexts;
using KairoApi.Model.LKP;

namespace KairoApi.Db.Repository
{
    public interface IStatusRepository : IBaseRepository<IKairoApiDbContext, LKP_StatusDao>
    {
    }
}