using Net.Core.Configuration;
using Net.Core.Infrastructure;

namespace Net.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add All controller
            services.AddControllers();

            //services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Add Cors Policy
            services.AddCors();

            services.AddRouting(option => option.LowercaseUrls = true);
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
                    case Core.Enum.DistributedCacheType.Memory:
                        services.AddDistributedMemoryCache(); break;
                    case Core.Enum.DistributedCacheType.Redis:
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
