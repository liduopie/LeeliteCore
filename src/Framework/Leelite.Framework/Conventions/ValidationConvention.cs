using System.Reflection;
using FluentValidation;
using Leelite.Commons.Convention;
using Leelite.Commons.Host;

namespace Leelite.Framework.Conventions
{
    public class ValidationConvention : IConventionRegistrar
    {
        public void RegisterAssembly(Assembly assembly)
        {
            HostManager.Context.ServiceDescriptors.AddValidatorsFromAssembly(assembly);
        }
    }
}
