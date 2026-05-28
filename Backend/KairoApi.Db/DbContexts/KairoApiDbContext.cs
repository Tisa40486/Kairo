using KairoApi.Data.DbContexts;
using KairoApi.Model;
using KairoApi.Model.LKP;
using Microsoft.EntityFrameworkCore;

namespace KairoApi.Db.DbContexts
{
    public class KairoApiDbContext : BaseDbContext<KairoApiDbContext>, IKairoApiDbContext
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

            modelBuilder.Entity<LKP_StatusDao>().HasData(
                    new LKP_StatusDao {Id = 1, Name = "To do"},
                    new LKP_StatusDao {Id = 2, Name = "Doing"},
                    new LKP_StatusDao {Id = 3, Name = " In Review"},
                    new LKP_StatusDao {Id = 4, Name = "Done"}
                );
        }
    }
}