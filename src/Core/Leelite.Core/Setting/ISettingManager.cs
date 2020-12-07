using Leelite.Commons.Lifetime;

//using Microsoft.Extensions.Configuration;

namespace Leelite.Core.Settings
{
    /// <summary>
    /// 配置管理
    /// </summary>
    public interface ISettingManager : ISingleton
    {
        /// <summary>
        /// 获取应用程序配置
        /// </summary>
        /// <returns>返回配置跟目录</returns>
        //IConfigurationRoot GetApplicationConfig();

        /// <summary>
        /// 刷新应用程序配置
        /// </summary>
        void ReloadApplicationConfig();

        /// <summary>
        /// 获取租户配置
        /// </summary>
        /// <param name="tenantId">租户Id</param>
        /// <returns>返回配置跟目录</returns>
        //IConfigurationRoot GetTenantConfig(long tenantId);

        /// <summary>
        /// 刷新租户配置
        /// </summary>
        /// <param name="tenantId">租户Id</param>
        void ReloadTenantConfig(long tenantId);

        /// <summary>
        /// 获取用户配置
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>返回配置跟目录</returns>
        //IConfigurationRoot GetUserConfig(long userId);

        /// <summary>
        /// 刷新用户配置
        /// </summary>
        /// <param name="userId">用户Id</param>
        void ReloadUserConfig(long userId);

        /// <summary>
        /// 获取应用选项
        /// </summary>
        /// <typeparam name="TOptions">选项类型</typeparam>
        /// <param name="name">选项名称</param>
        /// <returns>返回选项对象</returns>
        TOptions GetApplicationOptions<TOptions>(string name);

        /// <summary>
        /// 获取租户选项
        /// </summary>
        /// <typeparam name="TOptions">选项类型</typeparam>
        /// <param name="tenantId">租户Id</param>
        /// <param name="name">选项名称</param>
        /// <returns>返回选项对象</returns>
        TOptions GetTenantOptions<TOptions>(long tenantId, string name);

        /// <summary>
        /// 获取用户选项
        /// </summary>
        /// <typeparam name="TOptions">选项类型</typeparam>
        /// <param name="userId">用户Id</param>
        /// <param name="name">选项名称</param>
        /// <returns>返回选项对象</returns>
        TOptions GetUserOptions<TOptions>(long userId, string name);
    }
}
