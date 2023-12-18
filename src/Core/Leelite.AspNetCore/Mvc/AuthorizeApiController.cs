using Leelite.AspNetCore.Extensions;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.AspNetCore.Mvc
{
    /// <summary>
    /// API控制器基类
    /// </summary>
    [ApiController]
    [ApiKeyAuthorize]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "web")]
    public class AuthorizeApiController : ControllerBase
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
