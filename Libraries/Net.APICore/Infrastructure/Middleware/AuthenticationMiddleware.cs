using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Net.APICore.Model.Authentication;
using Net.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Net.Core.Configuration;
using Grpc.Net.Client;
using NetAuth.GrpcServices;

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

            var _api = Singleton<AppSettings>.Instance.Get<ApiConfig>();
            if (_api.EnableGrpcClient == true)
            {

                // Get token from header when request has been send 
                var token = context.Request.Headers.Authorization.FirstOrDefault<String>();

                // If token is not blank then it's will check valid
                if (!String.IsNullOrWhiteSpace(token))
                {
                    var chanel = EngineContext.Current.Resolve<GrpcChannel>();
                    var _client = new TokenProtoService.TokenProtoServiceClient(chanel);

                    var res = await _client.IsValidTokenAsync(new TokenRequest { Token = token });

                    // If Check valid has been error then send announce to client
                    if (res.Result == false)
                    {
                        // send response data announce to client
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await context.Response.WriteAsJsonAsync(new { message = "Authentication Fail" });
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}
