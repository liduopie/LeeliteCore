using Leelite.AspNetCore.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.AspNetCore.Mvc
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class PlatformControllerBase : AuthorizeBaseController
    {
    }
}
