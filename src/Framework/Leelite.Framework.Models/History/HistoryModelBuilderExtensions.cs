using Leelite.Framework.Models.History;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public static class HistoryModelBuilderExtensions
    {
        public static void HasHistory<TEntity, TKey>(this EntityTypeBuilder<TEntity> typeBuilder, int maxLength = 32)
            where TEntity : class, IHistory<TKey>
        {
            typeBuilder.HasMany(p => p.Histories).WithOne().HasForeignKey(p => p.DataId);
        }

        public static void AddHistoryRecord<TEntity, TKey>(this EntityTypeBuilder<TEntity> typeBuilder, string tableName = "", int maxLength = 32)
            where TEntity : class, IHistoryRecord<TKey>
        {
            if (string.IsNullOrEmpty(tableName))
            {
                tableName = typeof(TEntity).Name;
            }

            typeBuilder.HasKey(p => p.Id);
            typeBuilder.ToTable(tableName);

            typeBuilder.Property(p => p.DataId);

            if (typeof(TKey).Name == "string")
            {
                typeBuilder.Property(p => p.DataId).HasMaxLength(maxLength);
            }

            typeBuilder.Property(p => p.ModificationTime);
            typeBuilder.Property(p => p.ModifierId).HasMaxLength(maxLength);
            typeBuilder.Property(p => p.Modifier).HasMaxLength(maxLength);
            typeBuilder.Property(p => p.OriginalData).HasColumnType("json");
            typeBuilder.Property(p => p.NewData).HasColumnType("json");
            typeBuilder.Property(p => p.Summary).HasMaxLength(1024);
        }
    }
}
