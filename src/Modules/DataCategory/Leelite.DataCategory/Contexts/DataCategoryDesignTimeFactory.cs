using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.DataCategory.Contexts
{
    public class DataCategoryDesignTimeFactory : IDesignTimeDbContextFactory<DataCategoryContext>
    {
        public DataCategoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataCategoryContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            return new DataCategoryContext(optionsBuilder.Options);
        }
    }
}
