using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

using Leelite.Commons.Convention;
using Leelite.Commons.Host;
using Leelite.Core.Modular;
using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Core.Module.Store;

using McMaster.NETCore.Plugins;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Leelite.AspNetCore.Modular
{
    public class ModularManager : IModularManager, IModduleLoaderManager
    {
        private readonly ModularOptions _options;
        private readonly IModuleStore _store;
        private readonly AssemblyLoadContext _moduleLoadContext;
        private readonly IList<ModuleContext> _moduleContexts = new List<ModuleContext>();
        private readonly ILogger<ModularManager> _logger;

        private readonly IList<ModuleInfo> _infos;
        private readonly IList<IModule> _modules = new List<IModule>();

        public ModularManager(IOptions<ModularOptions> options, IModuleStore store)
        {
            _options = options.Value;
            _store = store;

            _moduleLoadContext = new AssemblyLoadContext("Modules", true);

            // 发现所有模块信息
            _infos = _store.Find();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            _logger = loggerFactory.CreateLogger<ModularManager>();
        }

        public IList<ModuleContext> ModuleContexts { get { return _moduleContexts; } }
        public IList<IModule> Modules { get { return _modules; } }

        public void Load(HostContext context)
        {
            _logger.LogInformation($"Find module infos {_infos.Count}.");

            var moduleTypes = new List<Type>();

            // 默认程序集中的模块
            foreach (var item in AssemblyLoadContext.Default.Assemblies)
            {
                foreach (var type in item.GetTypes().Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsAbstract))
                {
                    _logger.LogInformation($"Default AssemblyLoadContext {item.FullName} found module {type.Name}");

                    moduleTypes.Add(type);
                }
            }

            _logger.LogInformation($"Default AssemblyLoadContext find module types {moduleTypes.Count}.");

            foreach (var info in _infos)
            {
                var moduleContext = new ModuleContext();
                moduleContext.Info = info;

                var loader = PluginLoader.CreateFromAssemblyFile(info.GetAssemblyFilePath(),
                   // this ensures that the plugin resolves to the same version of DependencyInjection
                   // and ASP.NET Core that the current app uses
                   config =>
                   {
                       config.DefaultContext = _moduleLoadContext;
                       config.EnableHotReload = true;
                       config.PreferSharedTypes = true;
                   });

                loader.Reloaded += Loader_Reloaded;

                moduleContext.Loader = loader;
                moduleContext.Assemblies.Add(loader.LoadDefaultAssembly());

                foreach (var name in info.ReferencedAssemblies)
                {
                    var aasembly = loader.LoadAssemblyFromPath(Path.Combine(info.DirectoryPath, name));

                    moduleContext.Assemblies.Add(aasembly);
                }

                foreach (var item in moduleContext.Assemblies)
                {
                    foreach (var type in item.GetTypes().Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsAbstract))
                    {
                        _logger.LogInformation($"{item.FullName} found module {type.Name}");

                        moduleTypes.Add(type);
                    }
                }

                _moduleContexts.Add(moduleContext);
            }

            moduleTypes = moduleTypes.Union(FindAllDependedTypes(moduleTypes)).ToList();

            _logger.LogInformation($"Union module types {moduleTypes.Count}.");

            moduleTypes = moduleTypes.SortByDependencies(x => FindDependedModuleTypes(x));

            _logger.LogInformation($"Sort module types {moduleTypes.Count}.");

            moduleTypes.ForEach(c =>
            {
                _logger.LogInformation($"load module {c.FullName},hash {c.GetHashCode()}");

                _modules.Add((IModule)Activator.CreateInstance(c));
            });

            // 注册约定
            foreach (var module in _modules)
            {
                module.ConfigureConventions();
            }

            foreach (var item in _moduleContexts)
            {
                // 按照约定注册程序集
                foreach (var assembly in item.Assemblies)
                {
                    ConventionManager.RegisterAssembly(assembly);
                }
            }

            // 加载模块的依赖注入注册
            foreach (var startup in _modules)
            {
                startup.ConfigureServices(context);
            }
        }

        public IList<PluginLoader> GetLoaders()
        {
            var res = new List<PluginLoader>();

            foreach (var c in _moduleContexts)
            {
                res.Add((PluginLoader)c.Loader);
            }

            return res;
        }

        private void Loader_Reloaded(object sender, PluginReloadedEventArgs eventArgs)
        {
            if (_options.EnableHotStart)
                HostManager.Restart();
        }

        private static List<Type> FindAllDependedTypes(List<Type> types)
        {
            var dependedTypes = new List<Type>();
            foreach (var item in types)
            {
                dependedTypes = dependedTypes.Union(FindDependedModuleTypes(item)).ToList();
            }

            return dependedTypes;
        }

        /// <summary>
        /// Finds direct depended startups of a startup.
        /// </summary>
        public static List<Type> FindDependedModuleTypes(Type moduleType)
        {
            var list = new List<Type>();

            if (moduleType.GetTypeInfo().IsDefined(typeof(DependsOnAttribute), true))
            {
                var dependsOnAttributes = moduleType.GetTypeInfo().GetCustomAttributes(typeof(DependsOnAttribute), true).Cast<DependsOnAttribute>();
                foreach (var dependsOnAttribute in dependsOnAttributes)
                {
                    foreach (var dependedModuleType in dependsOnAttribute.DependedModuleTypes)
                    {
                        list.Add(dependedModuleType);
                    }
                }
            }

            return list;
        }
    }
}
