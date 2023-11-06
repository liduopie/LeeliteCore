using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Dev.Controllers
{
    [Area("Dev")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
