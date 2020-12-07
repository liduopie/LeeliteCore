using System.Collections.Generic;

namespace Leelite.Core.Module.Store
{
    /// <summary>
    /// 模块仓库
    /// </summary>
    public interface IModuleStore
    {
        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <returns>返回模块信息列表</returns>
        IList<ModuleInfo> Find();
    }
}
