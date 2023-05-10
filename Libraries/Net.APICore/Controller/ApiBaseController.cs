using Microsoft.AspNetCore.Mvc;
using Net.APICore.JsonResult;
using Net.APICore.Model;

namespace Net.APICore.Controller
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
