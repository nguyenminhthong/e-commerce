using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Infrastructure.Middleware
{
    public interface IMiddleware
    {
        int Order { get; }

        void ConfigureMiddleware(IApplicationBuilder app);
    }
}
