using Leelite.Commons.Lifetime;

namespace Leelite.Application.Settings
{
    /// <summary>
    /// 配置管理
    /// </summary>
    public interface ISettingManager : IScope
    {
        /// <summary>
        /// 刷新应用程序配置
        /// </summary>
        void ReloadApplicationConfig();

        /// <summary>
        /// 获取应用选项
        /// </summary>
        /// <typeparam name="TOptions">选项类型</typeparam>
        /// <returns>返回选项对象</returns>
        TOptions GetApplicationOptions<TOptions>();

        /// <summary>
        /// 获取租户选项
        /// </summary>
        /// <typeparam name="TOptions">选项类型</typeparam>
        /// <param name="tenantId">租户Id</param>
        /// <param name="name">选项名称</param>
        /// <returns>返回选项对象</returns>
        TOptions GetTenantOptions<TOptions>(long tenantId);

        /// <summary>
        /// 获取用户选项
        /// </summary>
        /// <typeparam name="TOptions">选项类型</typeparam>
        /// <param name="userId">用户Id</param>
        /// <param name="name">选项名称</param>
        /// <returns>返回选项对象</returns>
        TOptions GetUserOptions<TOptions>(long userId);
    }
}
