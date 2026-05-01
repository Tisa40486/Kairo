using KairoApi.Data.DbContexts;
using KairoApi.Model;
using Microsoft.EntityFrameworkCore;

namespace KairoApi.Db.DbContexts
{
    public class KairoApiDbContext : BaseDbContext, IKairoApiDbContext
    {
        public KairoApiDbContext(DbContextOptions<KairoApiDbContext> options) : base(options)
        {
        }
        public DbSet<UserDao> Users { get; set; }
        public DbSet<TaskDao> Tasks { get ; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskDao>()
                    .Property(p => p.Title)
                    .HasMaxLength(150)
                    .IsRequired();
        }
    }
}