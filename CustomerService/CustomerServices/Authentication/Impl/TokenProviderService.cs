using Microsoft.IdentityModel.Tokens;
using Net.Core.Configuration;
using Net.Core.Infrastructure;
using CustomerServices.Customers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerDomain.Customers;
using System.Security.Claims;

namespace CustomerServices.Authentication.Impl
{
    internal class TokenProviderService : ITokenProviderService
    {
        #region Variable
        private readonly ICustomerService _customerService;
        private readonly AppSettings _appSettings;
        #endregion

        #region CTor
        public TokenProviderService(
            AppSettings iAppSettings,
            ICustomerService iCustomerService)
        {
            _appSettings = iAppSettings;
            _customerService = iCustomerService;
        }
        #endregion

        public async Task<bool> IsValidTokenAsync(string token)
        {
            // get security config from app settings
            var _securityConfig = _appSettings.Get<SecurityConfig>();

            var tokenHandle = new JwtSecurityTokenHandler();

            // valid token with security key and Algogithm
            var tokenValidationResult = await tokenHandle.ValidateTokenAsync(token, new TokenValidationParameters
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

                if (!string.IsNullOrEmpty(userId))
                {
                    return await _customerService.IsExistCustomerByIdAsync(Int32.Parse(userId));
                }
            }
            return await Task.FromResult(false);
        }

        public Task<string> GenerateTokenAsync(Customer iCustomer)
        {
            // get security config from app settings
            var _securityConfig = _appSettings.Get<SecurityConfig>();
            var sysDate = DateTimeOffset.UtcNow;

            // expire time of token
            var expirationTime = sysDate.AddMinutes(_appSettings.Get<ApiConfig>().TokenExpireTimeMiniutes);

            var claims = new List<Claim>
            {
                new Claim(AuthenticationDefaults.ClaimUserId, iCustomer.Id.ToString()),
                new Claim(AuthenticationDefaults.ClaimUserGuid, iCustomer.CustomerGuid.ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, sysDate.ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, expirationTime.ToUnixTimeSeconds().ToString()),
            };

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityConfig.SecurityKey)), _securityConfig.Algorithm);

            var token = new JwtSecurityToken(new JwtHeader(signingCredentials), new JwtPayload(claims));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult(accessToken);
        }
    }
}
