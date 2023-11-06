using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.IdentityServer.Contexts.DesignTimeFactories
{
    public class ConfigurationDesignTimeFactory : IDesignTimeDbContextFactory<ConfigurationContext>
    {
        public ConfigurationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConfigurationContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            var storeOptions = new ConfigurationStoreOptions();

            var content = new ConfigurationContext(optionsBuilder.Options, storeOptions);

            content.StoreOptions = storeOptions;

            return content;
        }
    }
}
