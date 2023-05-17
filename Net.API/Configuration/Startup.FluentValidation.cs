using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.API.Validators;
using Net.API.ViewModel.Authentication;
using Net.APICore.Validator;
using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.API.Configuration
{
    public class FluentValidationStartup : IServiceStartup
    {
        public int Order => 150;

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {            
            services.AddTransient<IValidator<LoginModel>, LoginValidator>();
        }
    }
}
