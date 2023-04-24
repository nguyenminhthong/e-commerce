using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Configuration;
using Net.Core.Infrastructure;
using Net.Data.UnitOfWork;

namespace Net.Data
{
    public class DataBaseStartup : IServiceStartup
    {
        public int Order => 10;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var dbConfig = Singleton<DatabaseConfig>.Instance;

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(dbConfig.ConnectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
