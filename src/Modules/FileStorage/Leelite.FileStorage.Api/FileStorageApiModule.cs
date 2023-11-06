using Leelite.Core.Module;
using Leelite.Core.Module.Dependency;
using Leelite.Framework.WebApi;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.FileStorage.Api
{
    [DependsOn(typeof(FrameworkWebApiModule))]
    public class FileStorageApiModule : ModuleBase
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}
