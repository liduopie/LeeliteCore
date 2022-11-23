using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.Settings.Contexts
{
    public class SettingsDesignTimeFactory : IDesignTimeDbContextFactory<SettingsContext>
    {
        public SettingsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SettingsContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            return new SettingsContext(optionsBuilder.Options);
        }
    }
}
