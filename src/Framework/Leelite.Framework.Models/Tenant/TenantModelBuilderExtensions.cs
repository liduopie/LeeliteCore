
using Leelite.Framework.Models.Tenant;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public static class TenantModelBuilderExtensions
    {
        public static void HasTenant<TEntity, TKey>(this EntityTypeBuilder<TEntity> typeBuilder, int maxLength = 32)
            where TEntity : class, ITenant<TKey>
        {
            if (typeof(TKey).Name == "string")
            {
                typeBuilder.Property(p => p.TenantId).HasMaxLength(maxLength);
            }
        }
    }
}
