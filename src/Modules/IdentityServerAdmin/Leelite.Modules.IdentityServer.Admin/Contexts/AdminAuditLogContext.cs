using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skoruba.AuditLogging.EntityFramework.DbContexts;
using Skoruba.AuditLogging.EntityFramework.Entities;

namespace Leelite.Modules.IdentityServer.Admin.Contexts
{
    public class AdminAuditLogContext : DbContext, IAuditLoggingDbContext<AuditLog>
    {
        public AdminAuditLogContext(DbContextOptions<AdminAuditLogContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public DbSet<AuditLog> AuditLog { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AuditLog>().ToTable(TableConsts.AdminAuditLogs);
        }
    }
}
