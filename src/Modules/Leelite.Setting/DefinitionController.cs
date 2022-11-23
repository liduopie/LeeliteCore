using System.Collections.Generic;
using Leelite.Core.Settings;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Setting
{
    [ApiController]
    [Area("Setting")]
    [Route("api/[area]/[controller]")]
    public class DefinitionController : ControllerBase
    {
        private readonly ISettingManager _settingManager;
        public DefinitionController(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> Get()
        {
            // return _settingManager.GetApplicationConfig().AsEnumerable();
            return new List<KeyValuePair<string, string>>();
        }
    }
}
