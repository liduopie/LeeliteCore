using Leelite.Framework.Models.Version;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public static class VersionModelBuilderExtensions
    {
        public static void HasVersion<TEntity>(this EntityTypeBuilder<TEntity> typeBuilder)
            where TEntity : class, IVersion
        {
            typeBuilder.Property(p => p.Version).IsConcurrencyToken();
        }
    }
}
