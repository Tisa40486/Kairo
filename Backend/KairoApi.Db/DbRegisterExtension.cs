using KairoApi.Db.DbContexts;
using KairoApi.Db.Repository;
using KairoApi.Db.Repository.Implementation;
using KairoApi.Db.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace KairoApi.Db
{
    public static class DbRegisterExtension
    {
        public static void RegisterKairoApiDbContainer(this IServiceCollection services)
        {
            services.AddScoped<IKairoApiDbContext, KairoApiDbContext>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddScoped<IKairoApiUnitOfWork, KairoApiUnitOfWork>();
        }
    }
}