using System.Reflection;

using FluentValidation.AspNetCore;

using Leelite.Commons.Host;
using Leelite.Core.Modular;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.AspNetCore.Modular
{
    public static class ModularMvcBuilderExtensions
    {
        public static void AddModularPart(this IMvcBuilder builder)
        {
            var manager = HostManager.Context.HostServices.GetService<IModduleLoaderManager>();

            foreach (var loader in manager.GetLoaders())
            {
                var moduleAssembly = loader.LoadDefaultAssembly();

                // This loads MVC application parts from plugin assemblies
                var partFactory = ApplicationPartFactory.GetApplicationPartFactory(moduleAssembly);
                foreach (var part in partFactory.GetApplicationParts(moduleAssembly))
                {
                    builder.PartManager.ApplicationParts.Add(part);
                }

                // This piece finds and loads related parts, such as MvcAppPlugin1.Views.dll.
                var relatedAssembliesAttrs = moduleAssembly.GetCustomAttributes<RelatedAssemblyAttribute>();
                foreach (var attr in relatedAssembliesAttrs)
                {
                    var assembly = loader.LoadAssembly(attr.AssemblyFileName);
                    partFactory = ApplicationPartFactory.GetApplicationPartFactory(assembly);
                    foreach (var part in partFactory.GetApplicationParts(assembly))
                    {
                        builder.PartManager.ApplicationParts.Add(part);
                    }
                }
            }
        }

        public static void AddConfig(this IMvcBuilder builder)
        {
            // 添加 Mvc 其他配置
            builder.AddFluentValidation();

            // 运行时编译
            builder.AddRazorRuntimeCompilation(o =>
            {
                //foreach (var module in manager.GetModules())
                //{
                //    o.AdditionalReferencePaths.Add(module.Path);
                //}
            });

            // mvcBuilder.AddControllersAsServices(); // TODO:不确定用途
            builder.SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        public static void AddBuild(this IMvcBuilder builder)
        {
            var manager = HostManager.Context.HostServices.GetService<IModularManager>();

            foreach (var module in manager.Modules)
            {
                if (module is IMvcModule mvcModule)
                {
                    mvcModule.MvcBuild(builder);
                }
            }
        }
    }
}
