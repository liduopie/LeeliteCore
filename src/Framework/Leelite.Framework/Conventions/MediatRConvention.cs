using Leelite.Commons.Convention;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Leelite.Framework.Conventions
{
    public class MediatRConvention : IConventionRegistrar
    {
        public void RegisterAssembly(Assembly assembly, IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(assembly);
            });
        }
    }
}
