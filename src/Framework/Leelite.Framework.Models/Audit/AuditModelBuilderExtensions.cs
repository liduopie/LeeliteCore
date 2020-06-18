using Leelite.Framework.Models.Audit;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public static class AuditModelBuilderExtensions
    {
        public static void HasAudit<TEntity, TKey>(this EntityTypeBuilder<TEntity> typeBuilder, int maxLength = 32)
            where TEntity : class, IAudit<TKey>
        {
            if (typeof(TKey).Name == "string")
            {
                typeBuilder.Property(p => p.CreatorId).HasMaxLength(maxLength);
                typeBuilder.Property(p => p.LastModifierId).HasMaxLength(maxLength);
            }

            typeBuilder.Property(p => p.Creator).HasMaxLength(maxLength);
            typeBuilder.Property(p => p.CreationTime);

            typeBuilder.Property(p => p.Modifier).HasMaxLength(maxLength);
            typeBuilder.Property(p => p.LastModificationTime);

        }
    }
}
