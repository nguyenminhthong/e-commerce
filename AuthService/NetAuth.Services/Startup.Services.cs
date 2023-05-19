using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAuth.Services
{
    public class ServiceStartup : IServiceStartup
    {
        public int Order => 3000;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
