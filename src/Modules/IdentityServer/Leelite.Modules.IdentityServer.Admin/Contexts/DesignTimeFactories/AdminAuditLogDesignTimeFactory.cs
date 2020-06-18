using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Leelite.Modules.IdentityServer.Admin.Contexts.DesignTimeFactories
{
    public class AdminAuditLogDesignTimeFactory : IDesignTimeDbContextFactory<AdminAuditLogContext>
    {
        public AdminAuditLogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdminAuditLogContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=leelite;Username=postgres;Password=pgadmin");

            return new AdminAuditLogContext(optionsBuilder.Options);
        }
    }
}
