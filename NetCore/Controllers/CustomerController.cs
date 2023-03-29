using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = new JsonResult(new { message = "Hello" });
            return await Task.FromResult(result);
        }
    }
}
