using System;
using System.IO;
using HybridFS;
using HybridFS.FileStore.Contexts;
using HybridFS.FileSystem.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHybridFS_Sqlite(this IServiceCollection service, Action<HybridFSOptions> action = null)
        {
            service.AddHybridFS(action);

            service.AddSingleton<IFileStoreContextFactory, SqliteFileStoreContextFactory>();

            service.AddDbContext<FileSystemContext>((sp, option) =>
            {
                var fsOption = sp.GetService<HybridFSOptions>();

                var dbPath = Path.Combine(Directory.GetCurrentDirectory(), fsOption.RootPath, $"{fsOption.FileSystemDbName}.db");

                var connStr = $"Data Source={dbPath}";

                option.UseSqlite(connStr);
            });
        }
    }
}
