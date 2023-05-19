using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetOrder.ApiCore.Controller;

namespace NetOrder.Api.Controllers
{
    public class StoreController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return await Json();
        }
    }
}
