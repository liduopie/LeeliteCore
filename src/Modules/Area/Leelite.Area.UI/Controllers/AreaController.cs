using Microsoft.AspNetCore.Mvc;

namespace Leelite.Area.UI.Controllers
{
    [Route("Admin/[controller]/[action]")]
    public class AreaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
