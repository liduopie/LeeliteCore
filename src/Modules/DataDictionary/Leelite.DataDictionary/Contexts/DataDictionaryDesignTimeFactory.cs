using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.DataDictionary.Contexts
{
    public class DataDictionaryDesignTimeFactory : IDesignTimeDbContextFactory<DataDictionaryContext>
    {
        public DataDictionaryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataDictionaryContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            return new DataDictionaryContext(optionsBuilder.Options);
        }
    }
}
