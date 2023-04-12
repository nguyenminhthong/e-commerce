using Microsoft.AspNetCore.Mvc;

namespace Net.API.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
