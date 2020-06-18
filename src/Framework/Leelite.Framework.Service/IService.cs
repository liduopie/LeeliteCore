using System;
using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Domain.Repository;

namespace Leelite.Framework.Service
{
    /// <summary>
    /// 服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public interface IService<TEntity, TKey>
        where TEntity : IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
    {
        IRepository<TEntity, TKey> Repository { get; set; }
    }
}
