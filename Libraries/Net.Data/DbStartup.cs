using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Configuration;
using Net.Core.Infrastructure;
using Net.Data.Dapper;
using Net.Data.Repository;

namespace Net.Data
{
    public class DbStartup : IServiceStartup
    {
        public int Order => 10;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = Singleton<AppSettings>.Instance;

            var dbConfig = appSettings.Get<DatabaseConfig>();

            // Database context for EntityFramework
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(dbConfig.ConnectionString);
            });

            // While Dapper Enable
            if (appSettings.Get<ApiConfig>().EnableDapper)
            {
                // Add dependence Dapper Context
                services.AddScoped<IDapperContext, DapperContext>();
            }

            // config UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Config Repository Query with EntityFramework
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        }
    }
}
