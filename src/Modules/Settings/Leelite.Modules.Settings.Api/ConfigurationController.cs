using System.Collections.Generic;

using Leelite.Core.Settings;
using Leelite.Modules.Settings.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Leelite.Modules.Settings.Api
{
    [ApiController]
    [Area("Settings")]
    [Route("api/[area]/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ISettingManager _settingManager;
        public ConfigurationController(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        //[HttpGet("GetApplicationConfig")]
        //public IEnumerable<KeyValuePair<string, string>> GetApplicationConfig()
        //{
        //    return _settingManager.GetApplicationConfig().AsEnumerable();
        //}

        //[HttpGet("ReloadApplicationConfig")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult ReloadApplicationConfig()
        //{
        //    try
        //    {
        //        _settingManager.ReloadApplicationConfig();
        //    }
        //    catch (System.Exception e)
        //    {
        //        return BadRequest(e);
        //    }

        //    return Ok();
        //}

        //[HttpGet("GetTenantConfig/{tenantId}")]
        //public IEnumerable<KeyValuePair<string, string>> GetGetTenantConfig(long tenantId)
        //{
        //    return _settingManager.GetTenantConfig(tenantId).AsEnumerable();
        //}

        //[HttpGet("ReloadTenantConfig/{tenantId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult ReloadTenantConfig(long tenantId)
        //{
        //    try
        //    {
        //        _settingManager.ReloadTenantConfig(tenantId);
        //    }
        //    catch (System.Exception e)
        //    {
        //        return BadRequest(e);
        //    }

        //    return Ok();
        //}

        //[HttpGet("GetTenantConfig/{userId}")]
        //public IEnumerable<KeyValuePair<string, string>> GetUserConfig(long userId)
        //{
        //    return _settingManager.GetTenantConfig(userId).AsEnumerable();
        //}

        //[HttpGet("ReloadTenantConfig/{userId}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult ReloadUserConfig(long userId)
        //{
        //    try
        //    {
        //        _settingManager.ReloadTenantConfig(userId);
        //    }
        //    catch (System.Exception e)
        //    {
        //        return BadRequest(e);
        //    }

        //    return Ok();
        //}
    }
}
