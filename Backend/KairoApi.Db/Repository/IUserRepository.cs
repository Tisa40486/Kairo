using KairoApi.Data.Repository;
using KairoApi.Db.DbContexts;
using KairoApi.Model;

namespace KairoApi.Db.Repository;

public interface IUserRepository : IBaseRepository<IKairoApiDbContext, UserDao>    
{
    
    public  Task<UserDao> GetUserByEmailAsync(string email, bool withNoTracking = false);
}