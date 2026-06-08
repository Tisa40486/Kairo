using KairoApi.Data.Repository;
using KairoApi.Db.DbContexts;
using KairoApi.Model;
using Microsoft.EntityFrameworkCore;

namespace KairoApi.Db.Repository.Implementation;

public class UserRepository : BaseRepository<IKairoApiDbContext, UserDao>, IUserRepository
{
    public UserRepository(IKairoApiDbContext context) : base(context)
    {
    }
    
    // add the createUser, with addAndSave + encrypt password 

    public async Task<UserDao> GetUserByEmailAsync(string email, bool withNoTracking = false)
    {
        IQueryable<UserDao> query = _context.Set<UserDao>();
        if (withNoTracking)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(x => x.Email == email);
        
    }
}