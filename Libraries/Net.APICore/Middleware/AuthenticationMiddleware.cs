using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            await _next(context);
        }
    }
}
