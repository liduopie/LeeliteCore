using Leelite.Core.Modular;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.DevOps.Controllers
{
    [ApiController]
    [Area("DevOps")]
    [Route("api/[area]/[controller]")]
    public class AutoUpdateController : ControllerBase
    {
        private readonly IModularManager _modularManager;
        public AutoUpdateController(IModularManager modularManager)
        {
            _modularManager = modularManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
