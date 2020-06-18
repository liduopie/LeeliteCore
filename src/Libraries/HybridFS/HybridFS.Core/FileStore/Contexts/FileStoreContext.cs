using HybridFS.FileStore.Models;
using Microsoft.EntityFrameworkCore;

namespace HybridFS.FileStore.Contexts
{
    /// <summary>
    /// 文件存储上下文
    /// </summary>
    public class FileStoreContext : DbContext
    {
        public FileStoreContext(DbContextOptions<FileStoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// 文件条目集合
        /// </summary>
        public DbSet<FileEntry> FileEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileEntry>(builder =>
              {
                  builder.HasKey(f => f.Id);
                  builder.ToTable(TableConsts.FileEntry);

                  builder.Property(p => p.Length);
                  builder.Property(p => p.MD5).HasMaxLength(32);
                  builder.Property(p => p.ReferenceCount);
                  builder.Property(p => p.CreationTimeUtc);
                  builder.Property(p => p.Visits);
                  builder.Property(p => p.LastVisitTimeUtc);
                  builder.Property(p => p.Content);
                  builder.Property(p => p.PhysicalPath).HasMaxLength(1024);
              });
        }
    }
}
