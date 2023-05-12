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
    public class AuthenticationStartup : IServiceStartup
    {
        public int Order => 100;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
        }
    }
}
