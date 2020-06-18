using System;
using System.Linq;
using System.Reflection;
using Leelite.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        ///  Register all types in an assembly.
        /// </summary>
        /// <param name="assemblies">The assemblies from which to register types.</param>
        /// <returns>Registration builder allowing the registration to be configured.</returns>
        public static RegistrationData RegisterAssemblyTypes(this IServiceCollection services, params Assembly[] assemblies)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (assemblies == null) throw new ArgumentNullException(nameof(assemblies));

            var classTypes = assemblies.SelectMany(c => c.GetExportedTypes())
                .Where(c =>
                    c.IsClass &&
                    !c.IsAbstract &&
                    !c.IsGenericType &&
                    !c.IsNested
                ).ToList();

            return new RegistrationData(services, classTypes);
        }
    }
}
