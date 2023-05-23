using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Infrastructure;
using CustomerServices.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerServices.Authentication.Impl;
using CustomerServices.Authentication;

namespace CustomerServices
{
    public class ServiceStartup : IServiceStartup
    {
        public int Order => 3000;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITokenProviderService, TokenProviderService>();
        }
    }
}
