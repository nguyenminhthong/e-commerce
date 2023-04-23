﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net.WebApiCore.Controller;

namespace Net.API.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return await Execute();
        }
    }
}
