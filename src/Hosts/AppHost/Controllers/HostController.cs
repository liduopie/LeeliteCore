using Leelite.Commons.Host;
using Microsoft.AspNetCore.Mvc;

namespace AppHost.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HostController : ControllerBase
    {
        [HttpGet]
        public IActionResult Stop()
        {
            HostManager.Stop();
            return Ok();
        }

        [HttpGet]
        public IActionResult Restart()
        {
            HostManager.Restart();
            return Ok();
        }
    }
}