using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.Modules.MessageCenter.Contexts
{
    public class MessageDesignTimeFactory : IDesignTimeDbContextFactory<MessageContext>
    {
        public MessageContext CreateDbContext(string[] args)
        {
            var type = "PostgreSQL";
            var optionsBuilder = new DbContextOptionsBuilder<MessageContext>();

            if (args.Length > 0)
            {
                type = args[0];
            }

            switch (type)
            {
                case "MySql":
                    var serverVersion = new MySqlServerVersion(new Version(5, 7, 0));
                    optionsBuilder.UseMySql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin", serverVersion, c => c.MigrationsAssembly("Leelite.Modules.MessageCenter.MySql"));
                    break;
                default:
                    optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin", c => c.MigrationsAssembly("Leelite.Modules.MessageCenter.PostgreSQL"));
                    break;
            }

            return new MessageContext(optionsBuilder.Options);
        }
    }
}
