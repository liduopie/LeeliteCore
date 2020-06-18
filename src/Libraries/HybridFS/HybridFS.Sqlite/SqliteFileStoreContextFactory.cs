using System.Collections.Generic;
using System.IO;

using HybridFS.FileStore.ShardingRule;
using Microsoft.EntityFrameworkCore;

namespace HybridFS.FileStore.Contexts
{
    public class SqliteFileStoreContextFactory : IFileStoreContextFactory
    {
        private readonly HybridFSOptions _options;

        private readonly IDictionary<string, FileStoreContext> _contexts = new Dictionary<string, FileStoreContext>();

        public SqliteFileStoreContextFactory(HybridFSOptions options)
        {
            _options = options;
        }

        public FileStoreContext GetContext(long id)
        {
            var dbName = _options.FileStoreDbName;

            var rule = new DbShardingRule(_options.ExpandMode);

            var suffix = rule.BuildDbSuffix(id);

            if (!string.IsNullOrEmpty(suffix))
                dbName = dbName + "_" + suffix;

            if (_contexts.ContainsKey(dbName)) return _contexts[dbName];

            var dbPath = Path.Combine(Directory.GetCurrentDirectory(), _options.RootPath, $"{dbName}.db");

            var connStr = $"Data Source={dbPath}";

            var optionsBuilder = new DbContextOptionsBuilder<FileStoreContext>();

            optionsBuilder.UseSqlite(connStr);

            var context = new FileStoreContext(optionsBuilder.Options);

            _contexts.Add(dbName, context);

            return context;
        }
    }
}
