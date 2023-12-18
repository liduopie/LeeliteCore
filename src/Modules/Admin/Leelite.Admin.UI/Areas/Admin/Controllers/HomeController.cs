using Leelite.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminControllerBase
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
