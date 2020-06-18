using System;
using Leelite.Framework.Data.Store;
using Leelite.Framework.Domain.Model;

namespace Leelite.Framework.Domain.Repository
{
    /// <summary>
    /// 查询仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IQueryRepository<TEntity, TKey> : IQueryStore<TEntity>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
