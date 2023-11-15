using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileStorageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
