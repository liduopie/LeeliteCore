﻿using Leelite.Application.Settings;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Setting
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "manager")]
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
