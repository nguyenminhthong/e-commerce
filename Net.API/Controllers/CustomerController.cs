using Microsoft.AspNetCore.Mvc;
using Net.APICore.Controller;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            await Task.Delay(500);

            return await Execute();
        }
    }
}
