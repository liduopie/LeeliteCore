using Leelite.Framework.Domain.UnitOfWork;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EntityFrameworkServiceCollectionExtensions
    {
        public static void AddEntityFramework(this IServiceCollection services)
        {
            services.AddSharedConnection();
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
