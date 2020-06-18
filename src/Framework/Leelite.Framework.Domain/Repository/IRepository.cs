using System;
using Leelite.Commons.Lifetime;
using Leelite.Framework.Data.Store;
using Leelite.Framework.Domain.Model;

namespace Leelite.Framework.Domain.Repository
{
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IRepository<TEntity, TKey> : IQueryRepository<TEntity, TKey>, IStore<TEntity>, IScope
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
