using System.Collections.Generic;

namespace Leelite.Modules.Settings.Definition
{
    /// <summary>
    /// Defines setting definition manager.
    /// </summary>
    public interface ISettingDefinitionManager
    {
        /// <summary>
        /// 添加一个 <see cref="SettingDefinition"/> 设置定义。
        /// </summary>
        /// <param name="definition">设置定义对象</param>
        void AddSettingDefinition(SettingDefinition definition);

        /// <summary>
        /// Gets the <see cref="SettingDefinition"/> object with given unique name.
        /// Throws exception if can not find the setting.
        /// </summary>
        /// <param name="name">Unique name of the setting</param>
        /// <returns>The <see cref="SettingDefinition"/> object.</returns>
        SettingDefinition GetSettingDefinition(string name);

        /// <summary>
        /// Gets a list of all setting definitions.
        /// </summary>
        /// <returns>All settings.</returns>
        IReadOnlyList<SettingDefinition> GetAllSettingDefinitions();
    }
}
