using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Leelite.Commons.Assembly.Loader;
using Leelite.Commons.Host;
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
            var loader = HostManager.Context.HostServices.GetService<IAssemblyLoader>();

            var serviceTypes = new List<Type>();

            foreach (var assembly in loader.Assemblies)
            {
                var types = assembly.GetTypes().Where(c => c.IsClass && !c.IsAbstract && !c.IsGenericType && c.HasImplementedRawGeneric(typeof(ICrudService<,,,,,>)));

                serviceTypes.AddRange(types);
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
