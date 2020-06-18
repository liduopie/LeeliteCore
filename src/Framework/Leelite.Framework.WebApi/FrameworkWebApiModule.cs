using Leelite.AspNetCore.Modular;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Framework.WebApi
{
    public class FrameworkWebApiModule : MvcModuleStartupBase
    {
        public override void MvcBuild(IMvcBuilder builder)
        {
            builder.ConfigureApplicationPartManager(apm => apm.FeatureProviders.Add(new GenericControllerFeatureProvider()));
        }
    }
}
