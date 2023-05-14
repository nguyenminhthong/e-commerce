using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Configuration;
using Net.Core.Enum;
using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Infrastructure
{
    public class Startup : IServiceStartup
    {
        public int Order => 600;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = Singleton<AppSettings>.Instance;
            var apiConfig = appSettings.Get<ApiConfig>();

            if (apiConfig.EnableCache)
            {
                switch (apiConfig.DistributedCacheType)
                {
                    case DistributedCacheType.Memory:
                        services.AddDistributedMemoryCache(); break;
                    case DistributedCacheType.Redis:
                        var redisCacheConfig = appSettings.Get<RedisCacheConfig>();
                        services.AddStackExchangeRedisCache(options =>
                        {
                            options.Configuration = redisCacheConfig.ConnectionString;
                        });
                        break;
                }
            }
        }
    }
}
