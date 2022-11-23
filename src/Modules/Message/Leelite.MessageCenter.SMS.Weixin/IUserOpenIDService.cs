namespace Leelite.Modules.MessageCenter.Weixin
{
    /// <summary>
    /// 微信 OpenID 服务
    /// </summary>
    public interface IUserOpenIDService
    {
        /// <summary>
        /// 获取用户手机号
        /// </summary>
        /// <param name="appId">微信APPId</param>
        /// <param name="userId">用户Id</param>
        /// <returns>返回手机号</returns>
        public string GetOpenID(string appId, long userId);
    }
}
