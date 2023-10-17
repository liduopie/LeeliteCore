using System.Reflection;

using AutoMapper;

using Leelite.Commons.Convention;
using Leelite.Core.Mapper;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Framework.Conventions
{
    public class AutoMapperConvention : IConventionRegistrar
    {
        public void RegisterAssembly(Assembly assembly, IServiceCollection services)
        {
            var context = MapperConfigurationManager.Context;

            var types = assembly.GetTypes().Where(c => typeof(Profile).IsAssignableFrom(c));

            var profiles = new List<Profile>();

            foreach (var type in types)
            {
                if (type.IsGenericType) continue;
                profiles.Add(type.Assembly.CreateInstance(type.FullName) as Profile);
            }

            context.AddConfigure(c =>
            {
                c.AddProfiles(profiles);
            });
        }
    }
}
