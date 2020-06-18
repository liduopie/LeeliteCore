using Leelite.Core.Modular.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.AspNetCore.Modular
{
    public interface IMvcModuleStartup : IModuleStartup
    {
        void Configure(IApplicationBuilder app, IWebHostEnvironment env);

        void MvcBuild(IMvcBuilder builder);
    }
}
