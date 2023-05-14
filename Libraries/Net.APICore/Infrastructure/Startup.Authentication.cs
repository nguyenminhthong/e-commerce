using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Net.Core.Configuration;
using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Infrastructure
{
    public class AuthenticationStartup : IServiceStartup
    {
        public int Order => 200;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // add authentication
            var appSetting = Singleton<AppSettings>.Instance;
            var _securityConfig = appSetting.Get<SecurityConfig>();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityConfig.SecurityKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromDays(_securityConfig.ExpireDate)
                    };

                    // Handle event authentication request
                    options.Events = new JwtBearerEvents
                    {
                        // When Authentication request has been failed
                        OnAuthenticationFailed = (contex) =>
                        {
                            return Task.CompletedTask;
                        }
                    };
                });
        }
    }

    public class AuthenticationStartupApp : IAppBuilderStartup
    {
        public int Order => 200;

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}
