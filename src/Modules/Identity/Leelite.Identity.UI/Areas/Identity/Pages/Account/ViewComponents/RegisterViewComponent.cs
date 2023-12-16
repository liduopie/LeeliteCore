using Leelite.Application.Settings;
using Leelite.Identity.Options;
using Leelite.Web.Areas.Identity.Pages.Account.ViewComponents.Models;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Web.Areas.Identity.Pages.Account.ViewComponents
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
                Options = _settingManager.GetApplicationOptions<IdentityOptions>(),

                ReturnUrl = returnUrl
            };

            return View(model);
        }
    }
}
