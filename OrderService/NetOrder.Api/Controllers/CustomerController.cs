﻿using Microsoft.AspNetCore.Mvc;
using Net.APICore.Controller;

namespace NetCore.Controllers
{
    public class CustomerController : ApiBaseController
    {
        [HttpGet]
        [Route("customer/info")]
        public async Task<IActionResult> GetCustomer()
        {
            await Task.Delay(500);

            return await Json();
        }
    }
}
