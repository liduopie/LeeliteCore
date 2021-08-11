using Leelite.AspNetCore.Modular;
using Leelite.Core.Module.Dependency;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Framework.WebApi
{
    [DependsOn(typeof(FrameworkModule))]
    public class FrameworkWebApiModule : MvcModuleBase
    {
        public override void MvcBuild(IMvcBuilder builder)
        {
            builder.ConfigureApplicationPartManager(apm => apm.FeatureProviders.Add(new GenericControllerFeatureProvider()));
        }
    }
}
