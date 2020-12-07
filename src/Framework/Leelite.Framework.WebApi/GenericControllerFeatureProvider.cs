using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Leelite.Commons.Host;
using Leelite.Core.Modular;
using Leelite.Framework.Service;

using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Framework.WebApi
{
    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var manager = HostManager.Context.HostServices.GetService<IModularManager>();

            var serviceTypes = new List<Type>();

            foreach (var context in manager.ModuleContexts)
            {
                foreach (var assembly in context.Assemblies)
                {
                    var types = assembly.GetTypes().Where(c => c.IsClass && !c.IsAbstract && !c.IsGenericType && c.HasImplementedRawGeneric(typeof(ICrudService<,,,,,>)));

                    serviceTypes.AddRange(types);
                }
            }

            foreach (var service in serviceTypes)
            {
                var args = service.GetInterface(typeof(ICrudService<,,,,,>).Name).GetGenericArguments();
                var typeName = args[0].Name + "Controller";
                if (!feature.Controllers.Any(t => t.Name == typeName))
                {
                    // There's no controller for this entity, so add the generic version.
                    var controllerType = typeof(RESTfulController<,,,,,>)
                        .MakeGenericType(args).GetTypeInfo();
                    feature.Controllers.Add(controllerType);
                }
            }
        }
    }
}
