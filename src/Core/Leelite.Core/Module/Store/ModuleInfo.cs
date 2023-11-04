namespace Leelite.Core.Module.Store
{
    /// <summary>
    /// 模块描述信息
    /// </summary>
    public class ModuleInfo
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 应用程序集文件
        /// </summary>
        public string AssemblyFileName { get; set; } = "";

        /// <summary>
        /// 模块自身的程序集
        /// </summary>
        public IList<string> ReferencedAssemblies { get; set; } = new List<string>();

        /// <summary>
        /// 排斥的模块
        /// </summary>
        public IList<string> ExcludedModules { get; set; } = new List<string>();

        /// <summary>
        /// 模块所在路径
        /// </summary>
        public string DirectoryPath { get; set; } = "";

        /// <summary>
        /// 获取应用程序集路径
        /// </summary>
        /// <returns>返回应用程序集路径</returns>
        public string GetAssemblyFilePath()
        {
            return Path.Combine(DirectoryPath, AssemblyFileName);
        }
    }
}
