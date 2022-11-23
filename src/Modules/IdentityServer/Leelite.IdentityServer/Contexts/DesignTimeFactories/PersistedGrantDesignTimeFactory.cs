using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.Modules.IdentityServer.Contexts.DesignTimeFactories
{
    public class PersistedGrantDesignTimeFactory : IDesignTimeDbContextFactory<PersistedGrantContext>
    {
        public PersistedGrantContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PersistedGrantContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            var options = new OperationalStoreOptions();

            return new PersistedGrantContext(optionsBuilder.Options, options);
        }
    }
}
