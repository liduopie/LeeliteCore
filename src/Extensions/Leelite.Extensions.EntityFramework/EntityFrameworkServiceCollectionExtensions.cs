using System;
using System.Data.Common;
using Leelite.Extensions.EntityFramework;
using Leelite.Extensions.EntityFramework.Connection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            DbProviderFactories.RegisterFactory("Npgsql", Npgsql.NpgsqlFactory.Instance);
            DbProviderFactories.RegisterFactory("Sqlite", Data.Sqlite.SqliteFactory.Instance);
            DbProviderFactories.RegisterFactory("SqlClient", Data.SqlClient.SqlClientFactory.Instance);
        }

        public static void AddDbContext<TContext>(this IServiceCollection services, string connectionStringName, Action<IServiceProvider, DbContextOptionsBuilder> optionsAction = null)
             where TContext : DbContext
        {
            void action(IServiceProvider serviceProvider, DbContextOptionsBuilder builder)
            {
                var _configuration = serviceProvider.GetService<IConfiguration>();
                var _connectionFactory = serviceProvider.GetService<IConnectionFactory>();

                var options = serviceProvider.GetRequiredService<IProviderTypeOptions>();

                var dbProviderName = options.ProviderType;

                switch (dbProviderName)
                {
                    case DatabaseProviderType.InMemory:
                        builder.UseInMemoryDatabase(connectionStringName);
                        break;
                    case DatabaseProviderType.Sqlite:
                        builder.UseSqlite(_connectionFactory.GetConnection(connectionStringName), c => c.MigrationsAssembly(typeof(TContext).Assembly.GetName().Name));
                        break;
                    case DatabaseProviderType.SqlClient:
                        builder.UseSqlServer(_connectionFactory.GetConnection(connectionStringName), c => c.MigrationsAssembly(typeof(TContext).Assembly.GetName().Name));
                        break;
                    case DatabaseProviderType.MySql:
                        break;
                    case DatabaseProviderType.Npgsql:
                        builder.UseNpgsql(_connectionFactory.GetConnection(connectionStringName), c => c.MigrationsAssembly(typeof(TContext).Assembly.GetName().Name));
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
