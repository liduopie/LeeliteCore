using Leelite.Framework.Models.Tree;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public static class TreeModelBuilderExtensions
    {
        public static void HasTree<TEntity, TKey>(this EntityTypeBuilder<TEntity> typeBuilder, int maxLength = 32)
            where TEntity : class, ITree<TKey>
            where TKey : IEquatable<TKey>
        {
            if (typeof(TKey).Name == "string")
            {
                typeBuilder.Property(p => p.ParentId).HasMaxLength(maxLength);
            }

            typeBuilder.Property(p => p.Path).HasMaxLength(1024);
            typeBuilder.Property(p => p.Level);
            typeBuilder.Property(p => p.IsLeaf);
            typeBuilder.Property(p => p.ChildrenCount);
        }
    }
}
