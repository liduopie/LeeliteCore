using System.Linq;

using Leelite.Framework.Domain.Context;
using Leelite.Settings.Models.SettingValueAgg;

using Microsoft.EntityFrameworkCore;

namespace Leelite.Settings.Contexts
{
    public class SettingsContext : EFDbContext
    {
        public SettingsContext(DbContextOptions<SettingsContext> options) : base(options) { }

        public DbSet<SettingValue> SettingValues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SettingValue>(b =>
            {
                b.Ignore("Id");
                b.HasKey("_tenantId", "_userId", "_name");
                b.ToTable(TableConsts.SettingValue);

                b.Property("_tenantId").HasColumnName("TenantId");
                b.Property("_userId").HasColumnName("UserId");
                b.Property("_name").HasColumnName("Name").HasMaxLength(256);

                b.Property(p => p.Value).HasMaxLength(1024);

            });
        }
    }
}
