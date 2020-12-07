using Leelite.AspNetCore.Modular;
using Leelite.Core.Module.Dependency;
using Leelite.Framework.WebApi;

namespace Leelite.Modules.Identity.WebApi
{
    [DependsOn(typeof(FrameworkWebApiModule), typeof(IdentityModule))]
    public class IdentityWebApiModule : MvcModuleBase
    {
    }
}
