using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Leelite.Web.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IdentityOptions _options;

        public PrivacyModel(ILogger<PrivacyModel> logger, IOptionsMonitor<IdentityOptions> options)
        {
            _logger = logger;
            _options = options.CurrentValue;
        }

        public void OnGet()
        {
            //var id = User.GetUserId();
        }
    }
}
