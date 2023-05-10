using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Configuration;
using Net.Core.Enum;
using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Extensions
{
    public static partial class ServiceCollectionExtensions
    {

        /// <summary>
        /// Register HttpContextAccessor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        /// <summary>
        /// Add config distribute cache
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddDistributedCache(this IServiceCollection services)
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
