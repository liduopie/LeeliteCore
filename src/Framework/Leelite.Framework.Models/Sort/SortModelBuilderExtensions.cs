using Leelite.Framework.Models.Sort;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public static class SortModelBuilderExtensions
    {
        public static void HasSort<TEntity>(this EntityTypeBuilder<TEntity> typeBuilder)
            where TEntity : class, ISort
        {
            typeBuilder.Property(p => p.Sort);
        }
    }
}
