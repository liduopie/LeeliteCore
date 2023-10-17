using System.Collections.Immutable;

namespace Leelite.Application.Settings.Definition
{
    /// <summary>
    /// Implements <see cref="ISettingDefinitionManager"/>.
    /// </summary>
    internal class SettingDefinitionManager : ISettingDefinitionManager
    {
        private readonly IDictionary<string, SettingDefinition> _settings;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingDefinitionManager()
        {
            _settings = new Dictionary<string, SettingDefinition>();
        }

        /// <inheritdoc/>
        public void AddSettingDefinition(SettingDefinition definition)
        {
            if (_settings.ContainsKey(definition.Name))
            {
                throw new Exception("The definition has existed with name:" + definition.Name);
            }

            _settings.Add(definition.Name, definition);
        }

        /// <inheritdoc/>
        public SettingDefinition GetSettingDefinition(string name)
        {
            if (!_settings.TryGetValue(name, out var settingDefinition))
            {
                throw new Exception("There is no setting defined with name: " + name);
            }

            return settingDefinition;
        }

        /// <inheritdoc/>
        public IReadOnlyList<SettingDefinition> GetAllSettingDefinitions()
        {
            return _settings.Values.ToImmutableList();
        }
    }
}
