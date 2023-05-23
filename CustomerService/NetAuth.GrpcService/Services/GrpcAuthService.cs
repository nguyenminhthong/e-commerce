using CustomerServices.Authentication;
using CustomerServices.Customers;
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
        #region Variable
        private readonly ICustomerService _customerService;
        private readonly ITokenProviderService _tokenService;

        #endregion

        #region Constructor
        public GrpcAuthService(
            ICustomerService customerService,
            ITokenProviderService providerService)
        {
            _customerService = customerService;
            _tokenService = providerService;
        }

        #endregion

        #region Services
        public override async Task<AuthResponse> GenerateToken(AuthRequest request, ServerCallContext context)
        {
            var customer = await _customerService.GetCustomerByUserNameOrEmailAsync(request.Username);

            var _ = await _tokenService.GenerateTokenAsync(customer);

            return await Task.FromResult(new AuthResponse
            {
                AccessToken = "",
                Username = "",
                CustomerId = -1,
                CustomerGuid = "",
                CreatedAtUtc = "",
                ExpiresAtUtc = ""
            }) ;
        }
        #endregion
    }
}
