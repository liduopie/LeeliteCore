using System.Diagnostics;

using Leelite.Application;
using Leelite.Application.Settings;
using Leelite.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Leelite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISettingManager _settingManager;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ISettingManager settingManager, ILogger<HomeController> logger)
        {
            _settingManager = settingManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            model.Options = _settingManager.GetApplicationOptions<ApplicationOptions>();

            var settings = _settingManager.GetApplicationOptions<ApplicationSettings>();

            if (!string.IsNullOrEmpty(settings.StartUrl))
            {
                return Redirect(settings.StartUrl);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
