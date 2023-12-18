using Leelite.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Admin.Controllers
{
    public class FileStorageController : AdminControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
