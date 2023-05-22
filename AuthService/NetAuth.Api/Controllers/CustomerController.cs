using Microsoft.AspNetCore.Mvc;
using Net.APICore.Controller;

namespace NetAuth.Api.Controllers
{
    public class CustomerController : ApiBaseController
    {
        [HttpGet]
        public  Task Get()
        {
            return Json();
        }
    }
}
