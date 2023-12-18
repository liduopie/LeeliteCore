using Leelite.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Admin.Controllers
{
    public class SettingsController : AdminControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
