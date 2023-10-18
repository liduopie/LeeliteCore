using System.Data.Common;

using Leelite.Extensions.EntityFramework;
using Leelite.Extensions.EntityFramework.Connection;

using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using MySqlConnector;

using Npgsql;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class EntityFrameworkServiceCollectionExtensions
    {
        public static void AddSharedConnection(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionStringFactory, ConfigConnectionStringFactory>();
            services.AddScoped<IConnectionFactory, DefaultConnectionFactory>();

            AddDbProviders();

            services.AddSingleton<IProviderTypeOptions>(c =>
            {
                return c.GetService<IConfiguration>().Get<DatabaseProviderTypeOptions>();
            });
        }


        private static void AddDbProviders()
        {
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            DbProviderFactories.RegisterFactory("Npgsql", NpgsqlFactory.Instance);
            DbProviderFactories.RegisterFactory("Sqlite", SqliteFactory.Instance);
            DbProviderFactories.RegisterFactory("SqlClient", SqlClientFactory.Instance);
            DbProviderFactories.RegisterFactory("MySql", MySqlConnectorFactory.Instance);
        }

        public static void AddDbContext<TContext>(this IServiceCollection services, string connectionStringName, bool separateMigrations = false, Action<IServiceProvider, DbContextOptionsBuilder> optionsAction = null)
             where TContext : DbContext
        {
            void action(IServiceProvider serviceProvider, DbContextOptionsBuilder builder)
            {
                var _configuration = serviceProvider.GetService<IConfiguration>();
                var _connectionFactory = serviceProvider.GetService<IConnectionFactory>();

                var options = serviceProvider.GetRequiredService<IProviderTypeOptions>();

                var dbProviderName = options.ConnectionProviderType;

                // 如果是使用独立项目存放迁移，自动按照.**格式进行默认规则处理
                var migrationsAssemblyName = typeof(TContext).Assembly.GetName().Name;
                if (separateMigrations)
                {
                    migrationsAssemblyName = migrationsAssemblyName + "." + dbProviderName;
                }

                switch (dbProviderName)
                {
                    case DatabaseProviderType.InMemory:
                        builder.UseInMemoryDatabase(connectionStringName);
                        break;
                    case DatabaseProviderType.Sqlite:
                        builder.UseSqlite(_connectionFactory.GetConnection(connectionStringName), c => c.MigrationsAssembly(migrationsAssemblyName));
                        break;
                    case DatabaseProviderType.SqlClient:
                        builder.UseSqlServer(_connectionFactory.GetConnection(connectionStringName), c => c.MigrationsAssembly(migrationsAssemblyName));
                        break;
                    case DatabaseProviderType.MySql:
                        // Replace with your server version and type.
                        // Use 'MariaDbServerVersion' for MariaDB.
                        // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
                        // For common usages, see pull request #1233.
                        var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));

                        builder.UseMySql(_connectionFactory.GetConnection(connectionStringName), serverVersion, c => c.MigrationsAssembly(migrationsAssemblyName));
                        break;
                    case DatabaseProviderType.Npgsql:
                        builder.UseNpgsql(_connectionFactory.GetConnection(connectionStringName), c => c.MigrationsAssembly(migrationsAssemblyName));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(dbProviderName.ToString(), $@"The value needs to be one of {string.Join(", ", Enum.GetNames(typeof(DatabaseProviderType)))}.");
                }

                optionsAction?.Invoke(serviceProvider, builder);
            }

            services.AddDbContext<TContext>(action);

        }
    }
}
