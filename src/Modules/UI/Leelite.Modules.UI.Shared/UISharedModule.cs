using System.IO;
using Leelite.AspNetCore.Modular;
using Leelite.Core.Modular.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;

namespace Leelite.Modules.UI.Shared
{
    public class UISharedModule : MvcModuleStartupBase
    {
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

        }
    }
}
