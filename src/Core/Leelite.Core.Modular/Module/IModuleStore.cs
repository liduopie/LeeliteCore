using System.Collections.Generic;

namespace Leelite.Core.Modular.Module
{
    public interface IModuleStore
    {
        IList<ModuleInfo> Find();
    }
}
