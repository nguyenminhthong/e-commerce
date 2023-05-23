using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAuth.GrpcServices.Services
{
    public class GrpcAuthService : AuthProtoService.AuthProtoServiceBase
    {
        #region Services
        public override Task<AuthResponse> GenerateToken(AuthRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AuthResponse
            {
                AccessToken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
            });
        }
        #endregion
    }
}
