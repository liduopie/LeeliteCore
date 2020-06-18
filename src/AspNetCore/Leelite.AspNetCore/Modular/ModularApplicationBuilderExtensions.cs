using Leelite.Core.Modular;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.AspNetCore.Modular
{
    public static class ModularApplicationBuilderExtensions
    {
        public static void UseModularMvc(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var manager = app.ApplicationServices.GetService<IModularManager>();

            foreach (var startup in manager.ModuleStartups)
            {
                var mvcStartup = startup as IMvcModuleStartup;

                if (mvcStartup != null)
                    mvcStartup.Configure(app, env);
            }
        }
    }
}
