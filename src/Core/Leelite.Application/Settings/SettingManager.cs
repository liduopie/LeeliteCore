using Microsoft.Extensions.Configuration;

using System.Reflection;

namespace Leelite.Application.Settings
{
    public class SettingManager : ISettingManager
    {
        private IConfigurationRoot _appConfiguration;

        public SettingManager(IConfiguration configuration)
        {
            _appConfiguration = (IConfigurationRoot)configuration;
        }

        /// <inheritdoc/>
        public IConfigurationRoot GetApplicationConfig()
        {
            return _appConfiguration;
        }

        /// <inheritdoc/>
        public void ReloadApplicationConfig()
        {

            if (_appConfiguration == null) throw new NullReferenceException("_appConfiguration");

            _appConfiguration.Reload();
        }

        /// <inheritdoc/>
        public TOptions GetApplicationOptions<TOptions>()
        {
            var name = nameof(TOptions);

            var config = GetApplicationConfig();

            var options = CreateDefaultOptionsInstance<TOptions>();

            config.GetSection(name).Bind(options);

            return options;
        }

        /// <inheritdoc/>
        public TOptions GetTenantOptions<TOptions>(long tenantId)
        {
            var name = nameof(TOptions);

            var config = GetTenantConfig(tenantId);

            var options = CreateDefaultOptionsInstance<TOptions>();

            config.GetSection(name).Bind(options);

            return options;
        }

        /// <inheritdoc/>
        public TOptions GetUserOptions<TOptions>(long userId)
        {
            var name = nameof(TOptions);

            var config = GetUserConfig(userId);

            var options = CreateDefaultOptionsInstance<TOptions>();

            config.GetSection(name).Bind(options);

            return options;
        }

        private TOptions CreateDefaultOptionsInstance<TOptions>()
        {
            var type = typeof(TOptions);

            if (type == null) throw new NullReferenceException("Options type");
            if (string.IsNullOrEmpty(type.FullName)) throw new Exception("Options type name is empty");

            var instance = type.Assembly.CreateInstance(type.FullName);

            if (instance == null) throw new Exception("Unable to create Options instance");

            return (TOptions)instance;
        }

        /// <inheritdoc/>
        private IConfiguration GetTenantConfig(long tenantId)
        {
            var config = _appConfiguration.GetSection("Tenants");

            var tenantConfig = config.GetSection($"Tenant{tenantId}");

            return tenantConfig;
        }

        /// <inheritdoc/>
        private IConfiguration GetUserConfig(long userId)
        {
            var config = _appConfiguration.GetSection("Users");

            var userConfig = config.GetSection($"User{userId}");

            return userConfig;
        }
    }
}
