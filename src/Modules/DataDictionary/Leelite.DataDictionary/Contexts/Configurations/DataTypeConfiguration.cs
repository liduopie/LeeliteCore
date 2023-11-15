using Leelite.DataDictionary.Models.DataTypeAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.DataDictionary.Contexts.Configurations
{
    public class DataTypeConfiguration : IEntityTypeConfiguration<DataType>
    {
        public void Configure(EntityTypeBuilder<DataType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable(TableConsts.DataType);

            builder.Property(p => p.Id).HasMaxLength(64);
            builder.Property(p => p.Name).HasMaxLength(64).IsRequired();
            builder.Property(p => p.OwnerType).IsRequired();
        }
    }
}
