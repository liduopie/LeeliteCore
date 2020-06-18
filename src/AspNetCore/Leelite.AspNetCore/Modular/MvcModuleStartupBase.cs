using Leelite.Core.Modular.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.AspNetCore.Modular
{
    public abstract class MvcModuleStartupBase : ModuleStartupBase, IMvcModuleStartup
    {
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env) { }

        public virtual void MvcBuild(IMvcBuilder builder) { }
    }
}
