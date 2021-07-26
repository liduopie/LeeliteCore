using Leelite.Core.Cache;
using Leelite.Core.Mapper;

using MediatR;
using MediatR.Registration;

using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddLeeliteCore(this IServiceCollection services)
        {

            services.AddCache();

            services.AddMapper();

            services.AddSignalR();

            var serviceConfig = new MediatRServiceConfiguration();

            serviceConfig.AsScoped();

            ServiceRegistrar.AddRequiredServices(services, serviceConfig);
        }
    }
}
