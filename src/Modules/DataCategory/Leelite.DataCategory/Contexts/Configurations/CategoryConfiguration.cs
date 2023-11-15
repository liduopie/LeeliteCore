using Leelite.DataCategory.Models.CategoryAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.DataCategory.Contexts.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Name);
            builder.ToTable(TableConsts.Category);

            builder.Property(p => p.CategoryTypeId);
            builder.Property(p => p.Name).HasMaxLength(256);
            builder.Property(p => p.Icon).HasMaxLength(256);
            builder.Property(p => p.Description).HasMaxLength(512);

            builder.HasTree<Category, long>();
            builder.HasAudit<Category, long>();
            builder.HasEnabled();
            builder.HasSoftDelete();
        }
    }
}
