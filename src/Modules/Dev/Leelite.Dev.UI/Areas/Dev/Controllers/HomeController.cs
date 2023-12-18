using Leelite.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Dev.Controllers
{
    public class HomeController : DevControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
