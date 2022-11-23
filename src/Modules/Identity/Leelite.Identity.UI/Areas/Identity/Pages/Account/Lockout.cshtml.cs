using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Leelite.Identity.Models.UserAgg;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Leelite.Identity.UI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LockoutModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<LockoutModel> _logger;

        public LockoutModel(UserManager<User> userManager, ILogger<LockoutModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }


        public string UserName { get; set; }

        public string ProfilePicture { get; set; }

        public async Task OnGetAsync(string userName)
        {
            UserName = userName;

            var user = await _userManager.FindByNameAsync(UserName);
            ProfilePicture = user.ProfilePicture;
        }
    }
}
