using Microsoft.AspNetCore.Mvc;
using Net.API.ViewModel.Authentication;
using Net.APICore.Controller;
using Net.APICore.Model.Authentication;
using Net.Core.Services;
using System.Net;

namespace Net.API.Controllers
{
    [ApiController]
    public class TokenController : ApiBaseController
    {
        #region Variable
        private readonly ITokenProviderService tokenProviderService;
        #endregion

        #region CTor
        public TokenController(ITokenProviderService iTokenService)
        {
            tokenProviderService = iTokenService;
        }
        #endregion

        [HttpPost]
        [Route("/token", Name = "RequestToken")]
        [ProducesResponseType(typeof(TokenResponse), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] LoginModel model)
        {
            var res = new TokenResponse()
            {
                
            };
            return await Json<TokenResponse>(res);
        }

        [HttpPost]
        [Route("/guest-token", Name = "GuestToken")]
        [ProducesResponseType(typeof(TokenResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateGuest()
        {
            var res = new TokenResponse()
            {

            };
            return await Json<TokenResponse>(res);
        }

        [HttpPost]
        [Route("/token/check", Name = "ValidateToken")]
        public async Task<IActionResult> CheckToken()
        {
            return await Json();
        }
    }
}
