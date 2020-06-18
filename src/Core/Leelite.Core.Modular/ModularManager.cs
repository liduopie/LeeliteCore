using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Leelite.Commons.Assembly.Loader;
using Leelite.Commons.Convention;
using Leelite.Commons.Host;
using Leelite.Core.Modular.Dependency;
using Leelite.Core.Modular.Module;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core.Modular
{
    public class ModularManager : IModularManager
    {
        private readonly IModuleStore _store;

        public ModularManager()
        {
            _store = new DefaultModuleStore();
            ModuleEntries = new List<ModuleEntry>();
            ModuleStartups = new List<IModuleStartup>();
        }

        public IList<ModuleEntry> ModuleEntries { get; }

        public IList<IModuleStartup> ModuleStartups { get; }

        public void Load()
        {
            ModuleEntries.Clear();
            ModuleStartups.Clear();

            // 发现所有模块信息
            var moduleInfos = _store.Find();

            // load assemblies
            LoadAssemblies(moduleInfos);

            // load startups
            LoadStartups();
        }

        public void ConfigureServices(HostContext context)
        {
            // 注册约定
            foreach (var startup in ModuleStartups)
            {
                startup.ConfigureConventions();
            }

            // 按照约定注册程序集
            foreach (var entry in ModuleEntries)
            {
                foreach (var assembly in entry.Assemblys)
                {
                    ConventionManager.RegisterAssembly(assembly);
                }
            }

            // 加载启动项中的依赖注入注册
            foreach (var startup in ModuleStartups)
            {
                startup.ConfigureServices(context);
            }
        }

        private void LoadAssemblies(IList<ModuleInfo> infos)
        {
            var loader = HostManager.Context.HostServices.GetService<IAssemblyLoader>();

            foreach (var info in infos)
            {
                var entry = new ModuleEntry(info);

                foreach (var item in info.Assemblys)
                {
                    var assembly = loader.LoadFromAssemblyPath(Path.Combine(info.Path, item));

                    entry.Assemblys.Add(assembly);
                }

                foreach (var item in info.Views)
                {
                    var assembly = loader.LoadFromAssemblyPath(Path.Combine(info.Path, item));

                    entry.ViewAssemblys.Add(assembly);
                }

                ModuleEntries.Add(entry);
            }
        }

        private void LoadStartups()
        {
            var loader = HostManager.Context.HostServices.GetService<IAssemblyLoader>();

            var startupTypes = new List<Type>();

            foreach (var assembly in loader.Assemblies)
            {
                var types = assembly.GetTypes().Where(c => c.GetTypeInfo().IsClass && !c.IsAbstract && typeof(IModuleStartup).IsAssignableFrom(c));
                startupTypes.AddRange(types);
            }

            startupTypes.SortByDependencies(x => FindDependedStartupTypes(x));

            startupTypes.ForEach(c =>
            {
                ModuleStartups.Add((IModuleStartup)c.GetTypeInfo().Assembly.CreateInstance(c.FullName));
            });
        }

        /// <summary>
        /// Finds direct depended startups of a startup.
        /// </summary>
        public static List<Type> FindDependedStartupTypes(Type moduleType)
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
