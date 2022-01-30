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
            var manager = app.ApplicationServices.GetRequiredService<IModularManager>();

            foreach (var module in manager.Modules)
            {
                if (module is IMvcModule mvcModule)
                {
                    mvcModule.Configure(app, env);
                }
            }
        }
    }
}
