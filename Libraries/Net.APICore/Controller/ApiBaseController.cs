using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.APICore.JsonResult;
using Net.APICore.Model;

namespace Net.APICore.Controller
{
    public class ApiBaseController : ControllerBase
    {
        protected async Task<IActionResult> Json()
        {
            return await RawJsonResult.Send();
        }
        
        protected async Task<IActionResult> Error(string error = "")
        {
            return await RawJsonResult.Error(error);
        }

        protected async Task<IActionResult> BadReq<T>(T errors)
        {
            return await RawJsonResult.BabRequest(errors);
        }

        protected async Task<IActionResult> Json<T>(T iResponse, ApiStatus iMessage = ApiStatus.SUCCESS, int iStatusCode = 200) where T : class
        {
            return await RawJsonResult.Send(iResponse, iMessage, iStatusCode);
        }

    }
}
