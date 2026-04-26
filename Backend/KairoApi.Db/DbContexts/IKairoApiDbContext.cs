using KairoApi.Data.DbContexts;
using KairoApi.Model;
using Microsoft.EntityFrameworkCore;

namespace KairoApi.Db.DbContexts
{
    public interface IKairoApiDbContext : IBaseDbContext
    {
        public DbSet<UserDao> Users { get; set; }
        public DbSet<TaskDao> Tasks { get; set; }
    }
}
