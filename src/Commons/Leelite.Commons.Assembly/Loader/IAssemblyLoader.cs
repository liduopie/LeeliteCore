using System.Collections.Generic;

namespace Leelite.Commons.Assembly.Loader
{
    using System.Reflection;

    public interface IAssemblyLoader
    {
        IEnumerable<Assembly> Assemblies { get; }

        Assembly LoadFromAssemblyPath(string assemblyPath);

        void Unload();
    }
}
