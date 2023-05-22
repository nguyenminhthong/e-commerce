using Grpc.Core;
using GrpcServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAuth.GrpcServices.Services
{
    public class GrpcAuthentication : GrpcAuthService.GrpcAuthServiceBase
    {
        #region Services
        public override Task<TokenReply> GenerateToken(TokenRequest request, ServerCallContext context)
        {
            return Task.FromResult(new TokenReply
            {
                AccessToken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
            });
        }
        #endregion
    }
}
