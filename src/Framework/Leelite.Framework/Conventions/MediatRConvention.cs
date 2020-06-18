using System.Collections.Generic;
using System.Reflection;
using Leelite.Commons.Convention;
using Leelite.Commons.Host;
using MediatR.Registration;

namespace Leelite.Framework.Conventions
{
    public class MediatRConvention : IConventionRegistrar
    {
        public void RegisterAssembly(Assembly assembly)
        {
            IList<Assembly> assemblies = new List<Assembly>() {
                assembly
            };

            ServiceRegistrar.AddMediatRClasses(HostManager.Context.ServiceDescriptors, assemblies);
        }
    }
}
