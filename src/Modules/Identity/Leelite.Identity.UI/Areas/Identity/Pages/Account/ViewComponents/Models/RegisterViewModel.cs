using Leelite.Identity.Options;

namespace Leelite.Identity.UI.Areas.Identity.Pages.Account.ViewComponents.Models
{
    public class RegisterViewModel
    {
        public IdentityOptions Options { get; set; }

        public string ReturnUrl { get; set; }
    }
}
