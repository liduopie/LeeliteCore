namespace Leelite.Modules.MessageCenter.SMS
{
    /// <summary>
    /// 用户手机号服务
    /// </summary>
    public interface IUserPhoneService
    {
        /// <summary>
        /// 获取用户手机号
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>返回手机号</returns>
        public string GetPhone(long userId);
    }
}
