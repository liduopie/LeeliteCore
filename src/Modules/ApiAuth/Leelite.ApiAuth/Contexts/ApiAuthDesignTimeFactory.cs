using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.ApiAuth.Contexts
{
    public class ApiAuthDesignTimeFactory : IDesignTimeDbContextFactory<ApiAuthContext>
    {
        public ApiAuthContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiAuthContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            return new ApiAuthContext(optionsBuilder.Options);
        }
    }
}
