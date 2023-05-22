using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.GrpcClient
{
    public class GrpcServiceStartup : IServiceStartup
    {
        public int Order => 4000;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGrpcClientHandler, GrpcClientHandler>();
        }
    }
}
