using Net.Assembly;
using Net.Core.Configuration;
using Net.Core.Enum;
using Net.Core.Extensions;
using Net.Core.Infrastructure;

namespace Net.API.Extensions
{
    public static partial class ServiceCollectionExtensions
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

            // seperate instance to storage
            Singleton<ITypeFinder>.Instance = typeFinder;

            services.AddSingleton<ITypeFinder>(typeFinder);

            // create instance and store to dictionary as such as singleton
            var configs = new List<IConfig>();

            Parallel.ForEach(typeFinder.FindClassesOfType<IConfig>().Where(type => type != null).ToList(), (configType) =>
            {
                var instance = (IConfig) Activator.CreateInstance(configType);
                if (instance != null)
                    configs.Add(instance);
            });

            foreach (var config in configs)
            {
                builder.Configuration.GetSection(config?.Name).Bind(config, options => options.BindNonPublicProperties = true);
            }

            // create new instance appsetting
            var appsettings = new AppSettings(configs);
            Singleton<AppSettings>.Instance = appsettings;

            services.AddSingleton(appsettings);

            // Create engine and configure service provider
            var engine = EngineContext.Create();

            // Config all nescessary dependencice for services provider
            engine.ConfigureServices(services, builder.Configuration);
        }
    }
}
