using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.IdentityServer.Contexts.DesignTimeFactories
{
    public class PersistedGrantDesignTimeFactory : IDesignTimeDbContextFactory<PersistedGrantContext>
    {
        public PersistedGrantContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersistedGrantContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            var storeOptions = new OperationalStoreOptions();

            var context = new PersistedGrantContext(optionsBuilder.Options, storeOptions);

            context.StoreOptions = storeOptions;

            return context;
        }
    }
}
