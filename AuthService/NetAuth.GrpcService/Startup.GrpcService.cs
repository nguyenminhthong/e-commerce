using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Configuration;
using Net.Core.Infrastructure;
using NetAuth.GrpcServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAuth.GrpcServices
{
    public class GrpcServiceStartup : IServiceStartup
    {
        public int Order => 3001;

        public void ConfigureServices(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var _api = Singleton<AppSettings>.Instance.Get<ApiConfig>();
            if (_api.EnableGrpcServer)
            {
                services.AddGrpc();
            }
        }
    }

    public class GrpcApplicationStartup : IAppBuilderStartup
    {
        public int Order => 3001;

        public void Configure(IApplicationBuilder app)
        {
            var _api = Singleton<AppSettings>.Instance.Get<ApiConfig>();
            if (_api.EnableGrpcServer)
            {
                ((WebApplication)app).MapGrpcService<GrpcAuthentication>();
            }
        }
    }
}
