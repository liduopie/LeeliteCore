using Microsoft.AspNetCore.Mvc;

namespace Leelite.Admin.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
