using Leelite.Framework.Models.DataAccessSet;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public static class DataAccessSetModelBuilderExtensions
    {
        public static void HasDataAccessSet<TEntity, TKey>(this EntityTypeBuilder<TEntity> typeBuilder, int maxLength = 32)
            where TEntity : class, IDataAccessSet<TKey>
        {

            typeBuilder.Property(p => p.OwnerId).HasMaxLength(maxLength);

            typeBuilder.HasMany(p => p.Accesses).WithOne().HasForeignKey(p => p.DataId);
        }

        public static void AddAccessItem<TEntity, TKey>(this EntityTypeBuilder<TEntity> typeBuilder, string tableName = "", int maxLength = 32)
            where TEntity : class, IAccessItem<TKey>
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

            typeBuilder.Property(p => p.Permission).HasMaxLength(maxLength);
            typeBuilder.Property(p => p.UserId).HasMaxLength(maxLength);
            typeBuilder.Property(p => p.GroupId).HasMaxLength(maxLength);
            typeBuilder.Property(p => p.RoleId).HasMaxLength(maxLength);
        }
    }
}
