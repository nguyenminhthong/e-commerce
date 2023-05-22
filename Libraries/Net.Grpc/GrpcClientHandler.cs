using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetGrpc.Authentication;

namespace Net.GrpcClient
{
    public class GrpcClientHandler : IGrpcClientHandler
    {
        #region Variable
        //private readonly GrpcChannel _channel;

        #endregion

        public GrpcClientHandler()
        {
        }


        public Task Handle()
        {
            var _channel = GrpcChannel.ForAddress("https://localhost:32770/api/check-token");
            var _client = new AuthenticationService.AuthenticationServiceClient(_channel);

            var response = _client.GenerateToken(new TokenRequest
            {

            });
            return  Task.CompletedTask;
        }
    }
}
