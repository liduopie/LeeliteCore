using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.AspNetCore.Mvc
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminControllerBase : AuthorizeBaseController
    {
    }
}
