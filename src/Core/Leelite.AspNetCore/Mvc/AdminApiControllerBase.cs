using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.AspNetCore.Mvc
{
    /// <summary>
    /// 系统管理API控制器基类
    /// </summary>
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("api/[area]/[controller]")]
    [ApiExplorerSettings(GroupName = "base")]
    public class AdminApiControllerBase : AuthorizeApiController
    {
    }
}
