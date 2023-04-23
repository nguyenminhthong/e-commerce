using Net.Core.Configuration;
using Net.Core.Enum;
using Net.Core.Extensions;
using Net.Core.Infrastructure;

namespace Net.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        public static void ConfigureApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var configs = StartupEngine.AllNeededStartup
                                        .Select(configType => (IConfig)Activator.CreateInstance(configType))
                                        .ToList();

            foreach ( var config in configs)
            {
                builder.Configuration.GetSection(config.Name).Bind(config, options => options.BindNonPublicProperties = true);
            }

            services.AddSingleton(new AppSettings(configs));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
             
            // Add All controller
            services.AddControllers();

            services.AddEndpointsApiExplorer();

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
