using CustomerServices.Authentication;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAuth.GrpcServices.Services
{
    internal class GrpcTokenService : TokenProtoService.TokenProtoServiceBase
    {
        #region Variable
        private readonly ITokenProviderService _tokenService;

        #endregion
        public GrpcTokenService(ITokenProviderService providerService)
        {
            _tokenService = providerService;
        }
        public override async Task<TokenReply> IsValidToken(TokenRequest request, ServerCallContext context)
        {
            var result = await _tokenService.IsValidTokenAsync(request.Token);

            return await Task.FromResult(new TokenReply
            {
                Result = result
            });
        }
    }
}
