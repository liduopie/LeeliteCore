using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.Modules.FileStorage.Contexts
{
    public class FilesDesignTimeFactory : IDesignTimeDbContextFactory<FileStorageContext>
    {
        public FileStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FileStorageContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            return new FileStorageContext(optionsBuilder.Options);
        }
    }
}
