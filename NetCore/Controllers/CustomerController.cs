﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore.JsonResult;

namespace NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            await Task.Delay(500);

            return new RawJsonResult<String>("Hello");
        }
    }
}
