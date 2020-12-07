using Leelite.Core.Module;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.AspNetCore.Modular
{
    public interface IMvcModule : IModule
    {
        void Configure(IApplicationBuilder app, IWebHostEnvironment env);

        void MvcBuild(IMvcBuilder builder);
    }
}
