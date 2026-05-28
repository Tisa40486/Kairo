using KairoApi.Data.Repository;
using KairoApi.Db.DbContexts;
using KairoApi.Model;

namespace KairoApi.Db.Repository.Implementation;

public class UserRepository : BaseRepository<IKairoApiDbContext, UserDao>, IUserRepository
{
    public UserRepository(IKairoApiDbContext context) : base(context)
    {
    }
    
    // add the createUser, with addAndSave + encrypt password 
}