using Microsoft.Extensions.Configuration;

namespace Leelite.Core.Settings
{
    public class NullSettingManager : ISettingManager
    {
        private IConfigurationRoot _appConfiguration;
        private readonly IDictionary<long, IConfigurationRoot> _tenantConfigurations;
        private readonly IDictionary<long, IConfigurationRoot> _userConfigurations;

        public NullSettingManager()
        {
            _tenantConfigurations = new Dictionary<long, IConfigurationRoot>();
            _userConfigurations = new Dictionary<long, IConfigurationRoot>();
        }

        /// <inheritdoc/>
        public void ReloadApplicationConfig()
        {
            _appConfiguration = null;
        }

        /// <inheritdoc/>
        public void ReloadTenantConfig(long tenantId)
        {
            if (_tenantConfigurations.ContainsKey(tenantId))
                _tenantConfigurations.Remove(tenantId);
        }

        /// <inheritdoc/>
        public void ReloadUserConfig(long userId)
        {
            if (_userConfigurations.ContainsKey(userId))
                _userConfigurations.Remove(userId);
        }

        /// <inheritdoc/>
        public TOptions GetApplicationOptions<TOptions>(string name)
        {
            var config = GetApplicationConfig();

            var options = (TOptions)typeof(TOptions).Assembly.CreateInstance(typeof(TOptions).FullName);

            config.GetSection(name).Bind(options);

            return options;
        }

        /// <inheritdoc/>
        public TOptions GetTenantOptions<TOptions>(long tenantId, string name)
        {
            var config = GetTenantConfig(tenantId);

            var options = (TOptions)typeof(TOptions).Assembly.CreateInstance(typeof(TOptions).FullName);

            config.GetSection(name).Bind(options);

            return options;
        }

        /// <inheritdoc/>
        public TOptions GetUserOptions<TOptions>(long userId, string name)
        {
            var config = GetUserConfig(userId);

            var options = (TOptions)typeof(TOptions).Assembly.CreateInstance(typeof(TOptions).FullName);

            config.GetSection(name).Bind(options);

            return options;
        }

        /// <inheritdoc/>
        private IConfigurationRoot GetApplicationConfig()
        {
            if (_appConfiguration != null)
                return _appConfiguration;

            var values = new Dictionary<string, string>();

            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(values);

            _appConfiguration = builder.Build();

            return _appConfiguration;
        }

        /// <inheritdoc/>
        private IConfigurationRoot GetTenantConfig(long tenantId)
        {
            if (_tenantConfigurations.ContainsKey(tenantId))
                return _tenantConfigurations[tenantId];

            var values = new Dictionary<string, string>();

            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(values);

            var configuration = builder.Build();

            _tenantConfigurations.Add(tenantId, configuration);

            return configuration;
        }

        /// <inheritdoc/>
        private IConfigurationRoot GetUserConfig(long userId)
        {
            if (_userConfigurations.ContainsKey(userId))
                return _userConfigurations[userId];

            var values = new Dictionary<string, string>();

            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(values);

            var configuration = builder.Build();

            _userConfigurations.Add(userId, configuration);

            return configuration;
        }
    }
}
