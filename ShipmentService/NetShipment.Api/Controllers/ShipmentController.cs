using Microsoft.AspNetCore.Mvc;
using Net.APICore.Controller;

namespace NetShipment.Api.Controllers
{
    public class ShipmentController : ApiBaseController
    {
        #region Variable

        #endregion

        #region Constructor
        public ShipmentController() { }
        #endregion

        #region Public API

        [HttpGet]
        public Task<IActionResult> Get(int id)
        {
            return Json();
        }

        #endregion
    }
}
