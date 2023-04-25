using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.WebApiCore.Infrastructure
{
    public class RoutingStartup : IAppBuilderStartup
    {
        public int Order => 1000;

        public void Configure(IApplicationBuilder application)
        {
            
        }
    }
}
