using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.APICore.Validator;
using Net.Assembly;
using Net.Core.Configuration;
using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Infrastructure
{
    public class StartupCommon : IServiceStartup
    {
        public int Order => 100;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // add routing
            services.AddRouting(options =>
            {
                // change URI lowercase if using URI with controller name
                options.LowercaseUrls = true;
            });

            // Add All controler
            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

            // Add Cors
            var appSetting = Singleton<AppSettings>.Instance;
            var _securityConfig = appSetting.Get<SecurityConfig>();

            services.AddCors(options =>
            {
                options.AddPolicy(_securityConfig.CorsPolicyKey, options =>
                {
                    options
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyOrigin();
                });
            });

            // add FluentValidator
            var mvcBuilder = services
                .AddMvc(opt =>
                {
                    opt.Filters.Add(new ValidatorActionFilter());
                    opt.EnableEndpointRouting = false;
                });

            services.AddFluentValidationAutoValidation(options =>
            {
                var assemblies = mvcBuilder.PartManager.ApplicationParts.OfType<AssemblyPart>().Select(p => p.Assembly);
            });
        }
    }

    public class StartupCommonApp : IAppBuilderStartup
    {
        public int Order => 100;

        public void Configure(IApplicationBuilder app)
        {
            var appSetting = Singleton<AppSettings>.Instance;
            var _securityConfig = appSetting.Get<SecurityConfig>();

            app.UseRouting();

            app.UseCors(_securityConfig.CorsPolicyKey);
        }
    }
}
