using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using Leelite.Commons.Assembly.Loader;

namespace Leelite.AspNetCore.Assembly.Loader
{
    using System.Reflection;

    public class CollectibleAssemblyLoader : IAssemblyLoader
    {
        private CollectibleAssemblyLoadContext _context;

        public CollectibleAssemblyLoader()
        {
            _context = new CollectibleAssemblyLoadContext();
        }

        public IEnumerable<Assembly> Assemblies
        {
            get
            {
                return _context.Assemblies;
            }
        }

        public Assembly LoadFromAssemblyPath(string assemblyPath)
        {
            var defAssemblies = AssemblyLoadContext.Default.Assemblies;
            var assembly = defAssemblies.FirstOrDefault(c => c.ManifestModule.Name == Path.GetFileName(assemblyPath));

            if (assembly != null)
            {
                return assembly;
            }

            assembly = _context.Assemblies.FirstOrDefault(c => c.GetName().Name == Path.GetFileName(assemblyPath));

            if (assembly != null)
            {
                return assembly;
            }

            var pdb_path = Path.Combine(Path.GetDirectoryName(assemblyPath), Path.GetFileNameWithoutExtension(assemblyPath) + ".pdb");

            if (File.Exists(pdb_path))
            {
                using var fs = new FileStream(assemblyPath, FileMode.Open);
                using var pdb_fs = new FileStream(pdb_path, FileMode.Open);

                return _context.LoadFromStream(fs, pdb_fs);
            }
            else
            {
                using var fs = new FileStream(assemblyPath, FileMode.Open);

                return _context.LoadFromStream(fs);
            }

        }

        public void Unload()
        {
            _context.Unload();

            _context = new CollectibleAssemblyLoadContext();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
