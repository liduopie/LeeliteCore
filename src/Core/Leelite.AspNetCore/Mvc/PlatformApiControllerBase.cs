using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.AspNetCore.Mvc
{
    /// <summary>
    /// 平台管理API控制器基类
    /// </summary>
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    [Route("api/[area]/[controller]")]
    [ApiExplorerSettings(GroupName = "platform")]
    public class PlatformApiControllerBase : AuthorizeApiController
    {
    }
}
