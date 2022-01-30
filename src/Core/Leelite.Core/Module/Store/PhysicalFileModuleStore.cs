using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace Leelite.Core.Module.Store
{
    public class PhysicalFileModuleStore : IModuleStore
    {
        private readonly ModuleOptions _options;

        public PhysicalFileModuleStore(ModuleOptions options)
        {
            _options = options;
        }

        public IList<ModuleInfo> Find()
        {
            string _modulesPath = Path.Combine(Directory.GetCurrentDirectory(), _options.ModulesDirectory);

            var modules = new List<ModuleInfo>();

            if (!Directory.Exists(_modulesPath))
            {
                return modules;
            }

            using (var fileProvider = new PhysicalFileProvider(_modulesPath))
            {
                foreach (var subDirectory in fileProvider.GetDirectoryContents("").Where(c => c.IsDirectory))
                {
                    if (!File.Exists(Path.Combine(subDirectory.PhysicalPath, _options.ModuleManifestFileName)))
                    {
                        continue;
                    }

                    var builder = new ConfigurationBuilder()
                        .SetBasePath(subDirectory.PhysicalPath)
                        .AddJsonFile(_options.ModuleManifestFileName);

                    var configuration = builder.Build();

                    var module = new ModuleInfo();

                    configuration.Bind(module);

                    module.DirectoryPath = subDirectory.PhysicalPath;

                    modules.Add(module);
                }
            }

            return modules;
        }
    }
}
