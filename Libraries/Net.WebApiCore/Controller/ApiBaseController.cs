using Microsoft.AspNetCore.Mvc;
using Net.WebApiCore.JsonResult;
using Net.WebApiCore.Model;

namespace Net.WebApiCore.Controller
{
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        protected async Task<IActionResult> Execute<T>(T pResponse, ApiStatus pMessage = ApiStatus.SUCCESS, int pStatusCode = 200) where T : class
        {
            return await RawJsonResult.Send(pResponse, pMessage, pStatusCode);
        }

        protected async Task<IActionResult> Execute()
        {
            return await RawJsonResult.Send();
        }
    }
}
