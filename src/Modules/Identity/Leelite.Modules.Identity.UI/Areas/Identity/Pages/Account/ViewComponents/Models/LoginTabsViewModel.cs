using Leelite.Modules.Identity.SignIn.Options;

namespace Leelite.Modules.Identity.UI.Areas.Identity.Pages.Account.ViewComponents.Models
{
    public class LoginTabsViewModel
    {
        public LoginOptions Options { get; set; }

        public LoginType CurrentLoginType { get; set; }
    }
}
