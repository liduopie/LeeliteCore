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
            var manager = builder.Services.BuildServiceProvider().GetService<IModularManager>();

            foreach (var module in manager.ModuleEntries)
            {
                foreach (var controller in module.Assemblys)
                {

                    var controllerAssemblyPart = new AssemblyPart(controller);

                    builder.PartManager.ApplicationParts.Add(controllerAssemblyPart);
                }

                foreach (var view in module.ViewAssemblys)
                {
                    var viewAssemblyPart = new CompiledRazorAssemblyPart(view);

                    builder.PartManager.ApplicationParts.Add(viewAssemblyPart);
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

            // mvcBuilder.AddControllersAsServices();
            builder.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public static void AddBuild(this IMvcBuilder builder)
        {
            var manager = HostManager.Context.HostServices.GetService<IModularManager>();

            foreach (var startup in manager.ModuleStartups)
            {
                var mvcStartup = startup as IMvcModuleStartup;

                if (mvcStartup != null)
                    mvcStartup.MvcBuild(builder);
            }
        }
    }
}
