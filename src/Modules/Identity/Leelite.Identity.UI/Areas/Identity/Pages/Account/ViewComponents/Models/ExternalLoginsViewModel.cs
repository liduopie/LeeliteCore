using System.Collections.Generic;
using Leelite.Identity.SignIn.Options;

using Microsoft.AspNetCore.Authentication;

namespace Leelite.Identity.UI.Areas.Identity.Pages.Account.ViewComponents.Models
{
    public class ExternalLoginsViewModel
    {
        public LoginOptions Options { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }
    }
}
