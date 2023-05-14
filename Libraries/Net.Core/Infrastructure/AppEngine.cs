using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Assembly;
using Net.Core.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.Infrastructure
{
    internal partial class AppEngine : IEngine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //register engine
            services.AddSingleton<IEngine>(this);

            var typeFinder = Singleton<ITypeFinder>.Instance;

            var startupConfigurations = typeFinder.FindClassesOfType<IServiceStartup>();

            //create and sort instances of startup configurations
            var instances = startupConfigurations
                .Select(startup => (IServiceStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup?.Order);

            //configure services
            foreach (var instance in instances)
                instance?.ConfigureServices(services, configuration);

            //register mapper configurations
            AddAutoMapper();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        public void ConfigureRequestPipeline(IApplicationBuilder application)
        {
            //find startup configurations provided by other assemblies
            var typeFinder = Singleton<ITypeFinder>.Instance;
            var startupConfigurations = typeFinder.FindClassesOfType<IAppBuilderStartup>();

            //create and sort instances of startup configurations
            var instances = startupConfigurations
                .Select(startup => (IAppBuilderStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup?.Order);

            //configure request pipeline
            foreach (var instance in instances)
                instance?.Configure(application);
        }

        #region Private

        protected virtual void AddAutoMapper()
        {
            //find mapper configurations provided by other assemblies
            var typeFinder = Singleton<ITypeFinder>.Instance;
            var mapperConfigurations = typeFinder.FindClassesOfType<IOrderedMapperProfile>();

            //create and sort instances of mapper configurations
            var instances = mapperConfigurations
                .Select(mapperConfiguration => (IOrderedMapperProfile) Activator.CreateInstance(mapperConfiguration))
                .OrderBy(mapperConfiguration => mapperConfiguration?.Order);

            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                Parallel.ForEach(instances, (instance) =>
                {
                    cfg.AddProfile(instance?.GetType());
                });
            });

            //register
            AutoMapperConfiguration.Init(config);
        }
        #endregion
    }
}
