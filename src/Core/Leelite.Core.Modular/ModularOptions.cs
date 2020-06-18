namespace Leelite.Core.Modular
{
    public static class ModularOptions
    {
        /// <summary>
        /// 模块存储位置
        /// </summary>
        public static string ModulesDirectory { get; set; } = "Modules";

        /// <summary>
        /// 模块描述文件名称
        /// </summary>
        public static string ModuleManifestFileName { get; set; } = "module.json";
    }
}
