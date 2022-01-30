using HybridFS;
using HybridFS.FileStore.Contexts;
using HybridFS.FileSystem.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHybridFS_Sqlite(this IServiceCollection service, Action<HybridFSOptions>? action = null)
        {
            if (action != null)
            {
                service.AddHybridFS(action);
            }

            service.AddSingleton<IFileStoreContextFactory, SqliteFileStoreContextFactory>();

            service.AddDbContext<FileSystemContext>((sp, option) =>
            {
                var fsOption = sp.GetService<HybridFSOptions>();

                if (fsOption == null)
                {
                    fsOption = new HybridFSOptions();
                }

                var dbPath = Path.Combine(Directory.GetCurrentDirectory(), fsOption.RootPath, $"{fsOption.FileSystemDbName}.db");

                var connStr = $"Data Source={dbPath}";

                option.UseSqlite(connStr);
            });
        }
    }
}
