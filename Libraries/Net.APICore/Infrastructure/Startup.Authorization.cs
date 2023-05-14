using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Net.APICore.Authorization.Policies;
using Net.APICore.Authorization.Requirements;
using Net.APICore.Infrastructure.Middleware;
using Net.Core.Configuration;
using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Infrastructure
{
    public class AuthorizationStartup : IServiceStartup
    {
        public int Order => 300;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add Authorization with JWT Token
            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, (policy) =>
                {
                    policy.Requirements.Add(new AuthorizationSchemeRequirement());
                });
            });

            services.AddSingleton<IAuthorizationHandler, ValidSchemeAuthorizationPolicy>();
        }
    }

    public class AuthorizationStartupApp : IAppBuilderStartup
    {
        public int Order => 300;

        public void Configure(IApplicationBuilder app)
        {
            // use Authorization
            app.UseAuthorization();
        }
    }
}
