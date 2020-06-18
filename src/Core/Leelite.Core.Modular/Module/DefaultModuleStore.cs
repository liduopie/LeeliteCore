using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace Leelite.Core.Modular.Module
{
    public class DefaultModuleStore : IModuleStore
    {

        public IList<ModuleInfo> Find()
        {
            string _modulesPath = Path.Combine(Directory.GetCurrentDirectory(), ModularOptions.ModulesDirectory);

            return ResolverModules(_modulesPath);
        }

        private IList<ModuleInfo> ResolverModules(string path)
        {
            var modules = new List<ModuleInfo>();

            if (!Directory.Exists(path))
            {
                return modules;
            }

            using (var fileProvider = new PhysicalFileProvider(path))
            {
                foreach (var subDirectory in fileProvider.GetDirectoryContents("").Where(c => c.IsDirectory))
                {
                    if (!File.Exists(Path.Combine(subDirectory.PhysicalPath, ModularOptions.ModuleManifestFileName)))
                    {
                        modules.AddRange(ResolverModules(subDirectory.PhysicalPath));
                        continue;
                    }

                    var builder = new ConfigurationBuilder()
                        .SetBasePath(subDirectory.PhysicalPath)
                        .AddJsonFile(ModularOptions.ModuleManifestFileName);

                    var configuration = builder.Build();

                    var module = new ModuleInfo();

                    configuration.Bind(module);

                    module.Path = subDirectory.PhysicalPath;

                    modules.Add(module);
                }
            }

            return modules;
        }
    }
}
