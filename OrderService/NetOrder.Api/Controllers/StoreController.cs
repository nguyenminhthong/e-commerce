
using Grpc.Net.Client;
using GrpcClientServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.APICore.Controller;
using Net.Core.Configuration;

namespace NetOrder.Api.Controllers
{
    public class StoreController : ApiBaseController
    {
        #region Variable
        private readonly GrpcChannel _grpcChanel;
        #endregion

        public StoreController(GrpcChannel grpcChannel) 
        {
            _grpcChanel = grpcChannel;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var _client = new GrpcAuthService.GrpcAuthServiceClient(_grpcChanel);

            var response = await _client.GenerateTokenAsync(new TokenRequest
            {
                IsGuest = true,
                Password = "$admin",
                UserName = "user",
                RememberMe = false
            });

            return await Json(response.AccessToken);
        }
    }
}
