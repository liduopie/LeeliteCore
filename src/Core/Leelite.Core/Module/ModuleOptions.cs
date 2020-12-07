namespace Leelite.Core.Module
{
    /// <summary>
    /// 模块化选项
    /// </summary>
    public class ModuleOptions
    {
        /// <summary>
        /// 模块存储位置
        /// </summary>
        public string ModulesDirectory { get; set; } = "Modules";

        /// <summary>
        /// 模块描述文件名称
        /// </summary>
        public string ModuleManifestFileName { get; set; } = "module.json";
    }
}
