using Leelite.Commons.Convention;

using MediatR.Registration;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Leelite.Framework.Conventions
{
    public class MediatRConvention : IConventionRegistrar
    {
        public void RegisterAssembly(Assembly assembly, IServiceCollection services)
        {
            IList<Assembly> assemblies = new List<Assembly>() {
                assembly
            };

            ServiceRegistrar.AddMediatRClasses(services, assemblies, new MediatR.MediatRServiceConfiguration());
        }
    }
}
