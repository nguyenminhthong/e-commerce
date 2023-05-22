using GrpcService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAuth.GrpcServices.Services
{
    public class GrpcAuthentication : GrpcAuthService.GrpcAuthServiceBase
    {
        public GrpcAuthentication() { 
        
        }

        #region Services

        public async Task<TokenReply> GenerateToken(TokenRequest request)
        {

            return await Task.FromResult(new TokenReply
            {
                AccessToken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
            });
        }
        #endregion
    }
}
