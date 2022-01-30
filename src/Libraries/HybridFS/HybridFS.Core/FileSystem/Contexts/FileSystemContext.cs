using HybridFS.FileSystem.Models;

using Microsoft.EntityFrameworkCore;

namespace HybridFS.FileSystem.Contexts
{
    public class FileSystemContext : DbContext
    {
        public FileSystemContext(DbContextOptions<FileSystemContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// 文件条目集合
        /// </summary>
        public DbSet<FileIndex> FileIndexs => Set<FileIndex>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileIndex>(builder =>
            {
                builder.HasKey(f => f.Id);
                builder.ToTable(TableConsts.FileIndex);

                builder.Property(p => p.Path).HasMaxLength(1024);
                builder.Property(p => p.DirectoryPath).HasMaxLength(1024);
                builder.Property(p => p.Name).HasMaxLength(512);
                builder.Property(p => p.Extension).HasMaxLength(64);
                builder.Property(p => p.Length);
                builder.Property(p => p.MD5).HasMaxLength(32);
                builder.Property(p => p.FileEntryId);
                builder.Property(p => p.IsDirectory);
                builder.Property(p => p.LastModifiedUtc);
                builder.Property(p => p.Visits);
                builder.Property(p => p.LastVisitTimeUtc);
            });
        }
    }
}
