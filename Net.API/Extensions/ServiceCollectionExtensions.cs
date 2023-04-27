using Net.Assembly;
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
            // add accessor to HttpContext
            services.AddHttpContextAccessor();

            // register dependence typefinder
            var typeFinder = new TypeFinder();
            services.AddSingleton<ITypeFinder>(typeFinder);

            var configs = typeFinder.FindClassesOfType<IConfig>()
                                    .Select(_type => (IConfig) Activator.CreateInstance(_type))
                                    .ToList();

            //foreach ( var config in configs)
            //{
            //    builder.Configuration.GetSection(config?.Name).Bind(config, options => options.BindNonPublicProperties = true);
            //}

            //services.AddSingleton(new AppSettings(configs));

            // Create engine and configure service provider
            var engine = EngineContext.Create();

            // Config all nescessary dependencice for services provider
            engine.ConfigureServices(services, builder.Configuration);
        }

        /// <summary>
        /// Register HttpContextAccessor
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
