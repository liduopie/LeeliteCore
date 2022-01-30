using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Leelite.Framework.WebApi
{
    // Used to set the controller name for routing purposes. Without this convention the
    // names is 'GenericController`1[Widget]' rather than 'Widget'.
    //
    // Conventions can be applied as attributes or added to MvcOptions.Conventions.
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class GenericControllerNameConvention : Attribute, IControllerModelConvention
    {
        private readonly Type _type;
        public GenericControllerNameConvention(Type type)
        {
            _type = type;
        }


        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.GetGenericTypeDefinition() != _type)
            {
                // Not a GenericController, ignore.
                return;
            }

            var entityType = controller.ControllerType.GenericTypeArguments[0];
            controller.ControllerName = entityType.Name;

            var fullName = entityType.FullName;

            if (fullName == null) fullName = "";

            var area = fullName[(fullName.IndexOf("Modules") + 8)..];

            area = area.Substring(0, area.IndexOf("."));

            controller.RouteValues["area"] = area;
        }
    }
}
