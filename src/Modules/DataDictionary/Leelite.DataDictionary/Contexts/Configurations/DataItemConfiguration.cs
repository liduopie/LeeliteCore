using Leelite.DataDictionary.Models.DataItemAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.DataDictionary.Contexts.Configurations
{
    public class DataItemConfiguration : IEntityTypeConfiguration<DataItem>
    {
        public void Configure(EntityTypeBuilder<DataItem> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable(TableConsts.DataItem);

            builder.Property(p => p.DataTypeId).HasMaxLength(64).IsRequired();
            builder.Property(p => p.OrganizationId);
            builder.Property(p => p.Code).HasMaxLength(64);
            builder.Property(p => p.Value).HasMaxLength(64);
            builder.Property(p => p.Sort);
            builder.Property(p => p.Enabled);
            builder.Property(p => p.IsDeleted);
        }
    }
}
