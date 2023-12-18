using Leelite.AspNetCore.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Leelite.AspNetCore.Mvc.RazorPages
{
    [Authorize(Roles = "Admin")]
    public class AdminPageModel : PageModel
    {
        public long UserId
        {
            get
            {
                return User.GetUserId();
            }
        }
    }
}
