using KairoApi.Data.DbContexts;
using KairoApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace KairoApi.Db.DbContexts
{
    public class KairoApiDbContext : BaseDbContext, IKairoApiDbContext
    {
        public KairoApiDbContext(DbContextOptions<KairoApiDbContext> options) : base(options)
        {
        }

        public DbSet<UserDao> Users { get; set; }
        public DbSet<TaskDao> Tasks { get ; set;}

    }
}
