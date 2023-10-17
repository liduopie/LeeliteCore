using Microsoft.AspNetCore.Mvc;

namespace Leelite.Admin.UI.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]")]
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
