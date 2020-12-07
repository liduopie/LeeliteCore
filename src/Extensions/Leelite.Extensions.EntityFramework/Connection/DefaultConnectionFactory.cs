using System.Collections.Generic;
using System.Data.Common;

namespace Leelite.Extensions.EntityFramework.Connection
{
    public class DefaultConnectionFactory : IConnectionFactory
    {
        private readonly IConnectionStringFactory _stringFactory;
        private readonly Dictionary<string, DbConnection> _storage;
        private readonly DbProviderFactory _dbProviderFactory;

        public DefaultConnectionFactory(IProviderTypeOptions options, IConnectionStringFactory stringFactory)
        {
            _stringFactory = stringFactory;

            _storage = new Dictionary<string, DbConnection>();

            _dbProviderFactory = DbProviderFactories.GetFactory(options.ProviderType.ToString());
        }

        public DbConnection GetConnection(string name)
        {
            var connString = _stringFactory.GetConnectionString(name);


            if (!_storage.TryGetValue(connString, out DbConnection conn))
            {
                conn = _dbProviderFactory.CreateConnection();


                conn.ConnectionString = connString;

                _storage.Add(connString, conn);
            }

            return conn;
        }
    }
}
