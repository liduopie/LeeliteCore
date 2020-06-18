
using Leelite.Framework.Models.State;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    public static class StateModelBuilderExtensions
    {
        public static void HasState<TEntity, TState>(this EntityTypeBuilder<TEntity> typeBuilder)
            where TEntity : class, IState<TState>
        {
            typeBuilder.Property(p => p.State);
        }
    }
}
