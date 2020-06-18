using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Event;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.Framework.Domain
{
    public static class DomainServiceCollectionExtensions
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IDomainEventBus, DomainEventBus>();
        }
    }
}
