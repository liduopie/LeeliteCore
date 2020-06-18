using Leelite.Commons.Convention;
using Leelite.Commons.Host;
using Leelite.Core.Modular.Module;
using Leelite.Framework.Conventions;
using Leelite.Framework.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Framework
{
    public class FrameworkModule : ModuleStartupBase
    {
        public override void ConfigureConventions()
        {
            ConventionManager.AddRegistrar(new AutoMapperConvention());
            ConventionManager.AddRegistrar(new LifetimeConvention());
            ConventionManager.AddRegistrar(new ValidationConvention());
            ConventionManager.AddRegistrar(new MediatRConvention());
            ConventionManager.AddRegistrar(new CommandsConvention());
        }

        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddEFUnitOfWork();
            services.AddDomain();
        }
    }
}
