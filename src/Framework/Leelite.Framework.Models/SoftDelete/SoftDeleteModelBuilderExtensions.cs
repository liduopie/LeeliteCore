
using Leelite.Framework.Models.SoftDelete;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public static class SoftDeleteModelBuilderExtensions
    {
        public static void HasSoftDelete<TEntity>(this EntityTypeBuilder<TEntity> typeBuilder)
            where TEntity : class, ISoftDelete
        {
            typeBuilder.Property(p => p.IsDeleted);
        }
    }
}
