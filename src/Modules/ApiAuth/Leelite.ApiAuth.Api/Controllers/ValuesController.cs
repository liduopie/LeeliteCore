using System.Text;

using AspNetCore.Authentication.ApiKey;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.ApiAuth.Api.Controllers
{
    // [Authorize(AuthenticationSchemes = ApiKeyDefaults.AuthenticationScheme)]
    [ApiAuthorize]
    [ApiController]
    [ApiExplorerSettings(GroupName = "manager")]
    [Area("ApiAuth")]
    [Route("api/[area]/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("claims")]
        public ActionResult<string> Claims()
        {
            var user = User;

            var sb = new StringBuilder();
            foreach (var claim in User.Claims)
            {
                sb.AppendLine($"{claim.Type}: {claim.Value}");
            }
            return sb.ToString();
        }

        [HttpGet("forbid")]
        public new IActionResult Forbid()
        {
            return base.Forbid();
        }
    }
}
