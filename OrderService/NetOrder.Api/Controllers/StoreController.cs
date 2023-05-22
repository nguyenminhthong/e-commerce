using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.APICore.Controller;

namespace NetOrder.Api.Controllers
{
    public class StoreController : ApiBaseController
    {
        #region Variable

        #endregion

        public StoreController() 
        {
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Json();
        }
    }
}
