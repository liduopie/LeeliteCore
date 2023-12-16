using Leelite.Identity.Options;

namespace Leelite.Web.Areas.Identity.Pages.Account.ViewComponents.Models
{
    public class RegisterViewModel
    {
        public IdentityOptions Options { get; set; }

        public string ReturnUrl { get; set; }
    }
}
