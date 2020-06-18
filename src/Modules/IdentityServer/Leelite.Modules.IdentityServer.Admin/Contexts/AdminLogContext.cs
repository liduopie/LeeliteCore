using Microsoft.EntityFrameworkCore;
using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;
using Skoruba.IdentityServer4.Admin.EntityFramework.Interfaces;

namespace Leelite.Modules.IdentityServer.Admin.Contexts
{
    public class AdminLogContext : DbContext, IAdminLogDbContext
    {
        public DbSet<Log> Logs { get; set; }

        public AdminLogContext(DbContextOptions<AdminLogContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureLogContext(builder);
        }

        private void ConfigureLogContext(ModelBuilder builder)
        {
            builder.Entity<Log>(log =>
            {
                log.ToTable(TableConsts.AdminLogs);
                log.HasKey(x => x.Id);
                log.Property(x => x.Level).HasMaxLength(128);
            });
        }
    }
}
