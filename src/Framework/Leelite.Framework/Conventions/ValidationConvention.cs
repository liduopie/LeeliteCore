using FluentValidation;

using Leelite.Commons.Convention;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Leelite.Framework.Conventions
{
    public class ValidationConvention : IConventionRegistrar
    {

        public void RegisterAssembly(Assembly assembly, IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(assembly);
        }
    }
}
