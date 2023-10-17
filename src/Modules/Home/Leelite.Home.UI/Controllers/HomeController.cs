using Leelite.Application.Options;
using Leelite.Application.Settings;
using Leelite.Home.UI.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Diagnostics;

namespace Leelite.Home.UI.Controllers
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
