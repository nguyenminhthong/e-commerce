using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Net.Core.Configuration;
using Microsoft.AspNetCore.Mvc.Filters;
using Net.Assembly;
using Grpc.Net.Client;

namespace NetAuth.GrpcClient
{
    public class GrpcServiceStartup : IServiceStartup
    {
        public int Order => 4000;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var _api = Singleton<AppSettings>.Instance.Get<ApiConfig>();

            if (_api.EnableGrpc)
            {
                var _grpcSetting = Singleton<AppSettings>.Instance.Get<GrpcSettings>();

                var chanel = GrpcChannel.ForAddress(_grpcSetting.NetAuthService);
                services.AddSingleton(chanel);
            }
        }
    }
}
