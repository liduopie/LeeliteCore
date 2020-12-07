using System.Collections.Generic;

using McMaster.NETCore.Plugins;

namespace Leelite.AspNetCore.Modular
{
    public interface IModduleLoaderManager
    {
        IList<PluginLoader> GetLoaders();
    }
}
