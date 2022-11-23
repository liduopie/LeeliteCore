using Leelite.Core.Settings;
using Leelite.Identity.SignIn.Options;
using Leelite.Identity.UI.Areas.Identity.Pages.Account.ViewComponents.Models;
using Leelite.Settings.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.UI.Areas.Identity.Pages.Account.ViewComponents
{
    public class LoginTabsViewComponent : ViewComponent
    {
        private readonly ISettingManager _settingManager;

        public LoginTabsViewComponent(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        public IViewComponentResult Invoke(LoginType current)
        {
            var model = new LoginTabsViewModel();

            model.Options = _settingManager.GetApplicationOptions<LoginOptions>(nameof(LoginOptions));

            model.CurrentLoginType = current;

            return View(model);
        }
    }
}
