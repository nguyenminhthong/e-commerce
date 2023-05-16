using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Net.APICore.Model.Authentication;
using Net.Core.Infrastructure;
using Net.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Net.APICore.Infrastructure.Middleware
{
    public class AuthenticationMiddleware
    {
        #region Variable
        private readonly RequestDelegate _next;
        private readonly TokenOptions _tokenOptions;

        #endregion
        public AuthenticationMiddleware(RequestDelegate next, TokenOptions tokenOptions)
        {
            _next = next;
            _tokenOptions = tokenOptions;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // if request is login path then next (doesn't check valid token)
            if (context.Request.Path.Equals(new PathString(_tokenOptions.Path)))
            {
                await _next(context);
                return;
            }

            // The request is swagger then next
            if (context.Request.Path.ToString().Contains("swagger"))
            {
                await _next(context);
                return;
            }

            // Get token from header when request has been send 
            var token = context.Request.Headers.Authorization.FirstOrDefault<String>();
            var _tokenProviderService = EngineContext.Current.Resolve<ITokenProviderService>();

            // If token is not blank then it's will check valid
            if (!String.IsNullOrWhiteSpace(token))
            {
                // check valid token
                if (await _tokenProviderService.IsValidTokenAsync(token))
                {
                    await _next(context);
                    return;
                }
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                var res = new TokenFailResponse
                {
                    Message = "Authentication Fail"
                }; 

                // send response data announce to client
                await context.Response.WriteAsync(JsonConvert.SerializeObject(res));
                return;
            }
            await _next(context);
        }
    }
}
