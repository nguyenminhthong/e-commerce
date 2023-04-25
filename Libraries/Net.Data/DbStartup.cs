using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Configuration;
using Net.Core.Infrastructure;
using Net.Data.Dapper;

namespace Net.Data
{
    public class DbStartup : IServiceStartup
    {
        public int Order => 10;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = Singleton<AppSettings>.Instance;

            var dbConfig = appSettings.Get<DatabaseConfig>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(dbConfig.ConnectionString);
            });

            // IF Dapper Enable
            if (appSettings.Get<ApiConfig>().EnableDapper)
            {
                services.AddScoped<IDapperProvider, DapperProvider>();
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
