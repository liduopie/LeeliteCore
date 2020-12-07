using Leelite.Core.Settings;
using Leelite.Modules.Identity.Options;
using Leelite.Modules.Identity.UI.Areas.Identity.Pages.Account.ViewComponents.Models;
using Leelite.Modules.Settings.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Identity.UI.Areas.Identity.Pages.Account.ViewComponents
{
    public class RegisterViewComponent : ViewComponent
    {
        private readonly ISettingManager _settingManager;

        public RegisterViewComponent(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        public IViewComponentResult Invoke(string returnUrl)
        {
            var model = new RegisterViewModel
            {
                Options = _settingManager.GetApplicationOptions<IdentityOptions>(nameof(IdentityOptions)),

                ReturnUrl = returnUrl
            };

            return View(model);
        }
    }
}
