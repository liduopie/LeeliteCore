using Leelite.Application.Settings;
using Leelite.Identity.Models.UserAgg;
using Leelite.Identity.SignIn.Options;
using Leelite.Identity.UI.Areas.Identity.Pages.Account.ViewComponents.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.UI.Areas.Identity.Pages.Account.ViewComponents
{
    public class ExternalLoginsViewComponent : ViewComponent
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ISettingManager _settingManager;

        public ExternalLoginsViewComponent(SignInManager<User> signInManager, ISettingManager settingManager)
        {
            _signInManager = signInManager;
            _settingManager = settingManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> Logins { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new ExternalLoginsViewModel
            {
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
                Options = _settingManager.GetApplicationOptions<LoginOptions>()
            };

            return View(model);
        }
    }
}
