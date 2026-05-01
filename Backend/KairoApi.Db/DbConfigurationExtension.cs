using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using KairoApi.Db.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KairoApi.Db
{
    public static class DbConfigurationExtension
    {
        public static void AppKairoApiContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DataBase");

            services.AddDbContext<KairoApiDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                    mysqlOptions =>
                    {
                        mysqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                                    .UseRelationalNulls()
                                    .EnableRetryOnFailure(
                                        maxRetryCount: 5,
                                        maxRetryDelay: TimeSpan.FromSeconds(30),
                                        errorNumbersToAdd: null
                                    );
                        mysqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
                    }));
        }
    }
}