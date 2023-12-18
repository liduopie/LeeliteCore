using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.AspNetCore.Mvc
{
    /// <summary>
    /// 用户管理API控制器基类
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "user")]
    public class UserApiControllerBase : AuthorizeApiController
    {
    }
}
