﻿using System;
using System.Text.Json;

namespace Leelite.Modules.Settings.Definition
{
    /// <summary>
    /// Defines a setting.
    /// A setting is used to configure and change behavior of the application.
    /// </summary>
    public class SettingDefinition
    {
        /// <summary>
        /// Unique name of the setting.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Display name of the setting.
        /// This can be used to show setting to the user.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A brief description for this setting.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Scopes of this setting.
        /// Default value: <see cref="SettingScopes.Application"/>.
        /// </summary>
        public SettingScopes Scopes { get; set; }

        /// <summary>
        /// Is this setting inherited from parent scopes.
        /// Default: True.
        /// </summary>
        public bool IsInherited { get; set; }

        /// <summary>
        /// Gets/sets group for this setting.
        /// </summary>
        public SettingDefinitionGroup Group { get; set; }

        /// <summary>
        /// Default value of the setting.
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Can be used to store a custom object related to this setting.
        /// </summary>
        public JsonDocument CustomData { get; set; }

        /// <summary>
        /// Creates a new <see cref="SettingDefinition"/> object.
        /// </summary>
        /// <param name="name">Unique name of the setting</param>
        /// <param name="defaultValue">Default value of the setting</param>
        /// <param name="displayName">Display name of the permission</param>
        /// <param name="group">Group of this setting</param>
        /// <param name="description">A brief description for this setting</param>
        /// <param name="scopes">Scopes of this setting. Default value: <see cref="SettingScopes.Application"/>.</param>
        /// <param name="isVisibleToClients">This parameter is obsolete. Use <paramref name="clientVisibilityProvider"/> instead! Default: false</param>
        /// <param name="isInherited">Is this setting inherited from parent scopes. Default: True.</param>
        /// <param name="customData">Can be used to store a custom object related to this setting</param>
        /// <param name="clientVisibilityProvider">Client visibility definition for the setting. Default: invisible</param>
        public SettingDefinition(
            string name,
            string defaultValue,
            string displayName = null,
            SettingDefinitionGroup group = null,
            string description = null,
            SettingScopes scopes = SettingScopes.Application,
            bool isVisibleToClients = false,
            bool isInherited = true,
            JsonDocument customData = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            DefaultValue = defaultValue;
            DisplayName = displayName;
            Group = @group;
            Description = description;
            Scopes = scopes;
            IsInherited = isInherited;
            CustomData = customData;
        }
    }
}
