using System;
using Leelite.Framework.Domain.Model;

namespace Leelite.Framework.Domain.Aggregate
{
    /// <summary>
    /// 领域聚合根基类
    /// </summary>
    public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
