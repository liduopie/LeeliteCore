using System.Collections.Generic;
using Leelite.Modules.Identity.SignIn.Options;

using Microsoft.AspNetCore.Authentication;

namespace Leelite.Modules.Identity.UI.Areas.Identity.Pages.Account.ViewComponents.Models
{
    public class ExternalLoginsViewModel
    {
        public LoginOptions Options { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }
    }
}
