using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Senparc.Weixin;
using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.MvcExtension;

namespace Leelite.Modules.Weixin.Api.MP
{
    [ApiController]
    [Area("Weixin")]
    [Route("api/[area]/MP/[controller]")]
    public class OAuth2Controller : Controller
    {
        //下面换成账号对应的信息，也可以放入web.config等地方方便配置和更换
        public readonly string appId = Config.SenparcWeixinSetting.WeixinAppId;//与微信公众账号后台的AppId设置保持一致，区分大小写。
        private readonly string appSecret = Config.SenparcWeixinSetting.WeixinAppSecret;//与微信公众账号后台的AppId设置保持一致，区分大小写。

        // GET: api/[area]/MP/[controller]/Login/{code}
        [HttpGet("Login/{code}")]
        public ActionResult Login(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            OAuthAccessTokenResult result;

            //通过，用code换取access_token
            try
            {
                result = OAuthApi.GetAccessToken(appId, appSecret, code);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            if (result.errcode != ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }

            return Json(result);
        }

        // GET: api/[area]/MP/[controller]/GetUserInfo/{code}
        [HttpGet("GetUserInfo/{code}")]
        public ActionResult GetUserInfo(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }

            OAuthAccessTokenResult result;

            //通过，用code换取access_token
            try
            {
                result = OAuthApi.GetAccessToken(appId, appSecret, code);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            if (result.errcode != ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }

            //因为第一步选择的是OAuthScope.snsapi_userinfo，这里可以进一步获取用户详细信息

            try
            {
                OAuthUserInfo userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                return Json(result);
            }
            catch (ErrorJsonResultException ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
