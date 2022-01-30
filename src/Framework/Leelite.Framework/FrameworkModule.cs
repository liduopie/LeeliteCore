using Leelite.Commons.Convention;
using Leelite.Core.Module;
using Leelite.Framework.Conventions;
using Leelite.Framework.Domain;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Framework
{
    public class FrameworkModule : ModuleBase
    {
        public override void ConfigureConventions()
        {
            ConventionManager.AddRegistrar(new AutoMapperConvention());
            ConventionManager.AddRegistrar(new LifetimeConvention());
            ConventionManager.AddRegistrar(new ValidationConvention());
            ConventionManager.AddRegistrar(new MediatRConvention());
            ConventionManager.AddRegistrar(new CommandsConvention());
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEFUnitOfWork();
            services.AddDomain();
        }
    }
}
