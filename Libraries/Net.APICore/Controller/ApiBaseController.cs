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

        protected async Task<IActionResult> Json<T>(T iResponse) where T : class
        {
            return await RawJsonResult.Send(iResponse);
        }

        protected async Task<IActionResult> Error(string error = "")
        {
            return await RawJsonResult.Error(error);
        }

        protected async Task<IActionResult> BadRequest<T>(T errors)
        {
            return await RawJsonResult.BabRequest(errors);
        }
    }
}
