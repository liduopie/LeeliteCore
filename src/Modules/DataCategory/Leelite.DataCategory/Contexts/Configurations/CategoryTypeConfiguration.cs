using Leelite.DataCategory.Models.CategoryTypeAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.DataCategory.Contexts.Configurations
{
    public class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> builder)
        {
            builder.HasKey(r => r.Id);
            builder.ToTable(TableConsts.CategoryType);

            builder.Property(p => p.Name).HasMaxLength(256);
        }
    }
}
