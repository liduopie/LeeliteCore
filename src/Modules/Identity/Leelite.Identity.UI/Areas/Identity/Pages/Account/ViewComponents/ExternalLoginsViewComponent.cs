using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Leelite.Core.Settings;
using Leelite.Identity.Models.UserAgg;
using Leelite.Identity.SignIn.Options;
using Leelite.Identity.UI.Areas.Identity.Pages.Account.ViewComponents.Models;
using Leelite.Settings.Interfaces;

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

        public IList<AuthenticationScheme> Logins { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new ExternalLoginsViewModel
            {
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
                Options = _settingManager.GetApplicationOptions<LoginOptions>(nameof(LoginOptions))
            };

            return View(model);
        }
    }
}
