using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Leelite.Modules.Identity.Contexts
{
    public class IdentityDesignTimeFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            var services = new ServiceCollection();
            services.AddOptions<IdentityOptions>();

            var sp = services.BuildServiceProvider();

            return new IdentityContext(optionsBuilder.Options, sp.GetRequiredService<IOptions<IdentityOptions>>());
        }
    }
}
