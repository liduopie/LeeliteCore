using Leelite.Framework.Models.Enabled;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public static class EnabledModelBuilderExtensions
    {
        public static void HasEnabled<TEntity>(this EntityTypeBuilder<TEntity> typeBuilder)
           where TEntity : class, IEnabled
        {
            typeBuilder.Property(p => p.IsEnabled);
        }
    }
}
