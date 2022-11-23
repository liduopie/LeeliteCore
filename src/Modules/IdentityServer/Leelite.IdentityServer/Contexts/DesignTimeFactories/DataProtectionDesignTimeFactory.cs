using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.Modules.IdentityServer.Contexts.DesignTimeFactories
{
    public class DataProtectionDesignTimeFactory : IDesignTimeDbContextFactory<DataProtectionDbContext>
    {
        public DataProtectionDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataProtectionDbContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            return new DataProtectionDbContext(optionsBuilder.Options);
        }
    }
}
