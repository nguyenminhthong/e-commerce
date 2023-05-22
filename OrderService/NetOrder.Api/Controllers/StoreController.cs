using Grpc.Net.Client;
using GrpcServices;
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
        private readonly GrpcSettings _grpcSettings;
        #endregion

        public StoreController(GrpcChannel grpcChannel, GrpcSettings grpcSettings) 
        {
            _grpcChanel = grpcChannel;
            _grpcSettings = grpcSettings;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Json();
        }
    }
}
