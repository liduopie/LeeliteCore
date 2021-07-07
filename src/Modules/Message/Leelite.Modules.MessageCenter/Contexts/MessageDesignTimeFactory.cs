using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.Modules.MessageCenter.Contexts
{
    public class MessageDesignTimeFactory : IDesignTimeDbContextFactory<MessageContext>
    {
        public MessageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MessageContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            return new MessageContext(optionsBuilder.Options);
        }
    }
}
