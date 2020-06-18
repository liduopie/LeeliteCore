using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.Modules.IdentityServer.Admin.Contexts.DesignTimeFactories
{
    public class AdminLogDesignTimeFactory : IDesignTimeDbContextFactory<AdminLogContext>
    {
        public AdminLogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdminLogContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            return new AdminLogContext(optionsBuilder.Options);
        }
    }
}
