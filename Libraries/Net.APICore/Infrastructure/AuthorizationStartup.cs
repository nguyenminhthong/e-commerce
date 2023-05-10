using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        public int Order => 100;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add Authrization with JWT Token
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Bearer", policy =>
                {

                });
            });
        }
    }
}
