using Leelite.Commons.Convention;
using Leelite.Commons.Host;
using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Core.Module.Store;

using McMaster.NETCore.Plugins;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.Reflection;
using System.Runtime.Loader;

namespace Leelite.Core.Modular
{
    public class ModularManager : IModularManager
    {
        private readonly ModularOptions _options;
        private readonly IModuleStore _store;
        private readonly AssemblyLoadContext _moduleLoadContext;
        private readonly IList<ModuleContext> _moduleContexts = new List<ModuleContext>();
        private readonly ILogger<ModularManager> _logger;

        private readonly IList<ModuleInfo> _infos;
        private readonly IList<IModule> _modules = new List<IModule>();

        public ModularManager(IModuleStore store, ModularOptions options)
        {
            _options = options;
            _store = store;

            _moduleLoadContext = new AssemblyLoadContext("Modules", true);

            // 发现所有模块信息
            _infos = _store.Find();

            _logger = HostManager.DefaultHost.Services.GetService<ILoggerFactory>().CreateLogger<ModularManager>();

            Current = this;
        }

        public static ModularManager Current { get; private set; }

        public IList<ModuleContext> ModuleContexts { get { return _moduleContexts; } }
        public IList<IModule> Modules { get { return _modules; } }

        public void Loading(IServiceCollection services, IConfiguration configuration)
        {
            // 加载模块
            LoadModules();

            // 加载约定规则
            LoadConvention(services);

            // 加载模块的依赖注入注册
            LoadStartup(services, configuration);
        }

        public IList<PluginLoader> GetLoaders()
        {
            var res = new List<PluginLoader>();

            foreach (var c in _moduleContexts)
            {
                res.Add(c.Loader);
            }

            return res;
        }

        /// <summary>
        /// 发现模块
        /// </summary>
        private void LoadModules()
        {
            _logger.LogInformation($"Find module infos {_infos.Count}.");

            var moduleTypes = new List<Type>();

            // 默认程序集中的模块
            foreach (var item in AssemblyLoadContext.Default.Assemblies)
            {
                foreach (var type in item.GetTypes().Where(t => typeof(IModule).IsAssignableFrom(t) && !t.IsAbstract))
                {
                    _logger.LogInformation($"Default AssemblyLoadContext {item.GetName().Name}:{item.GetName().Version} found module {type.Name}.");

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
                        _logger.LogInformation($"{item.GetName().Name}:{item.GetName().Version} assembly found module {type.Name}");

                        moduleTypes.Add(type);
                    }
                }

                _moduleContexts.Add(moduleContext);
            }

            _logger.LogInformation($"Find module types {moduleTypes.Count}.");

            moduleTypes = moduleTypes.Union(FindAllDependedTypes(moduleTypes)).ToList();

            _logger.LogInformation($"Find depended module types {moduleTypes.Count}.");

            moduleTypes = moduleTypes.SortByDependencies(FindDependedModuleTypes);

            _logger.LogInformation($"Sort module types {moduleTypes.Count}.");

            moduleTypes.ForEach(c =>
            {
                _logger.LogInformation($"Load module {c.FullName},hash {c.GetHashCode()}");

                _modules.Add((IModule)Activator.CreateInstance(c));
            });
        }

        /// <summary>
        /// 加载约定规则
        /// </summary>
        /// <param name="services"></param>
        private void LoadConvention(IServiceCollection services)
        {
            // 初始化规则注册管理器
            ConventionManager.SetServices(services);

            // 注册约定
            foreach (var module in _modules)
            {
                module.ConfigureConventions();
            }

            var defaultAssemblies = from c in AssemblyLoadContext.Default.Assemblies
                                    where c.FullName.StartsWith("Leelite")
                                    select c;
            // 默认程序集
            foreach (var item in defaultAssemblies)
            {
                _logger.LogInformation($"RegisterAssembly {item.GetName().Name}");

                // 按照约定注册程序集
                ConventionManager.RegisterAssembly(item);
            }

            // 模块中的程序集
            foreach (var item in _moduleContexts)
            {
                // 按照约定注册程序集
                foreach (var assembly in item.Assemblies)
                {
                    ConventionManager.RegisterAssembly(assembly);
                }
            }
        }

        /// <summary>
        /// 加载模块的依赖注入注册
        /// </summary>
        /// <param name="services"></param>
        private void LoadStartup(IServiceCollection services, IConfiguration configuration)
        {
            foreach (var startup in _modules)
            {
                startup.ConfigureServices(services, configuration);
            }
        }

        private void Loader_Reloaded(object sender, PluginReloadedEventArgs eventArgs)
        {
            if (_options.EnableHotStart)
            {
                HostManager.WebApplication.StopAsync();
            }
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
