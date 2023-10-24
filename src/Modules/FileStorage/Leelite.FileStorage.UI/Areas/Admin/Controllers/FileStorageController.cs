using Microsoft.AspNetCore.Mvc;

namespace Leelite.FileStorage.UI.Areas.Admin.Controllers
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
