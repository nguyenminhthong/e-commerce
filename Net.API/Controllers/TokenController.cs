using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Net.API.ViewModel.Authentication;
using Net.APICore.Controller;
using Net.APICore.JsonResult;
using Net.APICore.Model.Authentication;
using Net.Core.Services;
using System.Net;

namespace Net.API.Controllers
{
    public class TokenController : ApiBaseController
    {
        #region Variable
        private readonly ITokenProviderService tokenProviderService;
        private readonly IValidator<LoginModel> loginValidator;
        #endregion

        #region CTor
        public TokenController(ITokenProviderService iTokenService, IValidator<LoginModel> iLoginValidator)
        {
            tokenProviderService = iTokenService;
            loginValidator = iLoginValidator;
        }
        #endregion

        [HttpPost]
        [Route("token", Name = "RequestToken")]
        [ProducesResponseType(typeof(TokenResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorModel), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] LoginModel model)
        {
            var _validateResult = loginValidator.Validate(model);

            if (!_validateResult.IsValid)
            {
                _validateResult.AddToModelState(ModelState);
                return BadRequest();
            }
            var res = new TokenResponse()
            {
                
            };
            return await Json<TokenResponse>(res);
        }

        [HttpPost]
        [Route("guest-token", Name = "GuestToken")]
        [ProducesResponseType(typeof(TokenResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateGuest()
        {
            var res = new TokenResponse()
            {

            };
            return await Json<TokenResponse>(res);
        }

        [HttpPost]
        [Route("check-token", Name = "CheckToken")]
        public async Task<IActionResult> CheckToken()
        {
            return await Json();
        }

    }
}
