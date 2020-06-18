using Leelite.Framework.Domain.Context;
using Leelite.Modules.FileStorage.Models.FileItemAgg;

using Microsoft.EntityFrameworkCore;

namespace Leelite.Modules.FileStorage.Contexts
{
    public class FileStorageContext : EFDbContext
    {
        public FileStorageContext(DbContextOptions<FileStorageContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of Users.
        /// </summary>
        public virtual DbSet<FileItem> FileInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileItem>(builder =>
            {
                builder.HasKey(f => f.Id);
                builder.ToTable(TableConsts.FileItem);

                builder.HasTenant<FileItem, long>();
                builder.HasAudit<FileItem, long>();
                builder.HasState<FileItem, FileState>();
                builder.HasSoftDelete();

                builder.Property(p => p.ModuleCode).HasMaxLength(32);
                builder.Property(p => p.Name).HasMaxLength(512);
                builder.Property(p => p.Path).HasMaxLength(1024);
                builder.Property(p => p.Length);
                builder.Property(p => p.MD5).HasMaxLength(32);
                builder.Property(p => p.Visits);
                builder.Property(p => p.LastVisitTime);
            });
        }
    }
}
