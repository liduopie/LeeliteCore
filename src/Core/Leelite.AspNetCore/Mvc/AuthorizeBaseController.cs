using Leelite.AspNetCore.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.AspNetCore.Mvc
{
    [Authorize]
    public class AuthorizeBaseController : Controller
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
