using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Infrastructure;
using NetAuth.GrpcService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAuth.GrpcServices.Configuration
{
    public class GrpcServiceStartup : IServiceStartup
    {
        public int Order => 3001;

        public void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddGrpc();

        }
    }

    public class GrpcApplicationStartup : IAppBuilderStartup
    {
        public int Order => 3001;

        public void Configure(IApplicationBuilder app)
        {
            ((WebApplication)app).MapGrpcService<GrpcAuthentication>();
        }
    }
}
