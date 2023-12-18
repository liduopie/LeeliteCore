using Leelite.AspNetCore.Extensions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.AspNetCore.Mvc
{
    [Area("Dev")]
    [Authorize(Roles = "Dev")]
    public class DevControllerBase : AuthorizeBaseController
    {
    }
}
