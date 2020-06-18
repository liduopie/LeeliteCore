using Leelite.Framework.Domain.UnitOfWork;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EntityFrameworkServiceCollectionExtensions
    {
        public static void AddEFUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
