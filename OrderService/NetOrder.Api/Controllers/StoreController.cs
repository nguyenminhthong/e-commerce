
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.APICore.Controller;
using Net.Core.Configuration;
using NetAuth.GrpcServices;

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
            var _client = new AuthProtoService.AuthProtoServiceClient(_grpcChanel);

            var response = await _client.GenerateTokenAsync(new AuthRequest
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
