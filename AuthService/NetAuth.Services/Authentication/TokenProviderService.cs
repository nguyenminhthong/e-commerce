using Microsoft.IdentityModel.Tokens;
using Net.Core.Configuration;
using Net.Core.Infrastructure;
using Net.Core.Services;
using NetAuth.Services.Customers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAuth.Services.Authentication
{
    internal class TokenProviderService : ITokenProviderService
    {
        #region Variable
        private readonly ICustomerService customerService;
        #endregion

        #region CTor
        public TokenProviderService(ICustomerService iCustomerService)
        {
            customerService = iCustomerService;            
        }
        #endregion

        public async Task<bool> IsValidTokenAsync(string token)
        {
            // get security config from app settings
            var appSetting = Singleton<AppSettings>.Instance;
            var _securityConfig = appSetting.Get<SecurityConfig>();

            var tokenHandle = new JwtSecurityTokenHandler();

            // valid token with security key and Algogithm
            var tokenValidationResult = await tokenHandle.ValidateTokenAsync(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.FromDays(_securityConfig.ExpireDate),
                IssuerSigningKey = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityConfig.SecurityKey)), _securityConfig.Algorithm).Key
            });

            // Token has been accepted after check
            if (tokenValidationResult.IsValid)
            {
                var ClaimsIdentity = tokenValidationResult.ClaimsIdentity;
                // If user identity existed in system
                var userId = ClaimsIdentity.Claims.Where(claim => claim.Type.Equals(AuthenticationDefaults.ClaimUserId)).FirstOrDefault()?.Value;

                if (!String.IsNullOrEmpty(userId))
                {
                    return await Task.FromResult(true);
                }

                // Case Guest Signin
                var userGuest = ClaimsIdentity.Claims.Where(claim => claim.Type.Equals(AuthenticationDefaults.ClaimUserGuid)).FirstOrDefault()?.Value;
                if (!String.IsNullOrEmpty(userGuest))
                {
                    return await customerService.IsExistGuestCustomerAsync(userGuest);
                }
            }
            return await Task.FromResult(false);
        }

        public Task<string> GenerateToken()
        {

            return Task.FromResult("");
        }
    }
}
