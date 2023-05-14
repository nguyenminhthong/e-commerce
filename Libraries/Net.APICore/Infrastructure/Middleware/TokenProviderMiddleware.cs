using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Infrastructure.Middleware
{
    public class TokenOptions
    {
        public string Path { get; set; }

        public TimeSpan Expiration { get; set; }

        public SigningCredentials SigningCredentials { get; set; }
    }

    public class TokenProviderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenOptions _options;

        public TokenProviderMiddleware(RequestDelegate next, TokenOptions options)
        {
            _next = next;
            _options = options; 
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers.Authorization;
            await _next(context);
        }
    }
}
