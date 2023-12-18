using System.Text;

using Leelite.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.Api.Controllers
{
    [Area("Identity")]
    [Route("api/[area]/[controller]")]
    public class AuthorizeController : AuthorizeApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "AllowAnonymous", "OK" };
        }

        [HttpGet("claims")]
        public ActionResult<string> Claims()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"UserId:{UserId}");

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
