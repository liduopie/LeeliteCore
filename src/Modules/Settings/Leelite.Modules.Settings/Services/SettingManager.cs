using System.Collections.Generic;
using System.Linq;

using Leelite.Core.Settings;
using Leelite.Modules.Settings.Dtos.SettingValueDtos;
using Leelite.Modules.Settings.Interfaces;

using Microsoft.Extensions.Configuration;

namespace Leelite.Modules.Settings.Services
{
    /// <inheritdoc/>
    public class SettingManager : ISettingManager
    {
        private readonly ISettingValueService _service;
        private IConfigurationRoot _appConfiguration;
        private readonly IDictionary<long, IConfigurationRoot> _tenantConfigurations;
        private readonly IDictionary<long, IConfigurationRoot> _userConfigurations;

        public SettingManager(ISettingValueService service)
        {
            _service = service;
            _tenantConfigurations = new Dictionary<long, IConfigurationRoot>();
            _userConfigurations = new Dictionary<long, IConfigurationRoot>();
        }

        /// <inheritdoc/>
        public IConfigurationRoot GetApplicationConfig()
        {
            if (_appConfiguration != null)
                return _appConfiguration;

            var valueDtos = _service.Get(new SettingValueQueryParameter());

            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(valueDtos.ToDictionary(s => s.Id.Name, s => s.Value));

            _appConfiguration = builder.Build();

            return _appConfiguration;
        }

        /// <inheritdoc/>
        public IConfigurationRoot GetTenantConfig(long tenantId)
        {
            if (_tenantConfigurations.ContainsKey(tenantId))
                return _tenantConfigurations[tenantId];

            var valueDtos = _service.Get(new SettingValueQueryParameter() { TenantId = tenantId });

            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(valueDtos.ToDictionary(s => s.Id.Name, s => s.Value));

            var configuration = builder.Build();

            _tenantConfigurations.Add(tenantId, configuration);

            return configuration;
        }

        /// <inheritdoc/>
        public IConfigurationRoot GetUserConfig(long userId)
        {
            if (_userConfigurations.ContainsKey(userId))
                return _userConfigurations[userId];

            var valueDtos = _service.Get(new SettingValueQueryParameter() { UserId = userId });

            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(valueDtos.ToDictionary(s => s.Id.Name, s => s.Value));

            var configuration = builder.Build();

            _userConfigurations.Add(userId, configuration);

            return configuration;
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
    }
}
