using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace Leelite.Extensions.EntityFramework.Connection
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        private readonly IConnectionStringFactory _stringFactory;
        private Dictionary<string, DbConnection> _storage;
        private DbProviderFactory _dbProviderFactory;

        public DefaultConnectionFactory(IProviderTypeOptions options, IConnectionStringFactory stringFactory)
        {
            _stringFactory = stringFactory;

            _storage = new Dictionary<string, DbConnection>();

            var dbProviderName = options.ProviderType;

            _dbProviderFactory = DbProviderFactories.GetFactory(options.ProviderType.ToString());
        }

        public DbConnection GetConnection(string name)
        {
            var connString = _stringFactory.GetConnectionString(name);

            DbConnection conn;

            if (!_storage.TryGetValue(connString, out conn))
            {
                conn = _dbProviderFactory.CreateConnection();


                conn.ConnectionString = connString;

                _storage.Add(connString, conn);
            }

            return conn;
        }
    }
}
