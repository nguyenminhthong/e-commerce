using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
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
    public class MiddlewareStartup : IAppBuilderStartup
    {
        public int Order => 400;

        public void Configure(IApplicationBuilder app)
        {
            var appSetting = Singleton<AppSettings>.Instance;
            var _securityConfig = appSetting.Get<SecurityConfig>();

            // use middleware to check token JWT
            app.UseMiddleware<TokenProviderMiddleware>(new TokenOptions
            {
                Path = _securityConfig.PathLogin,
                Expiration = TimeSpan.FromDays(_securityConfig.ExpireDate),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityConfig.SecurityKey)), SecurityAlgorithms.HmacSha256)
            });
        }
    }
}
