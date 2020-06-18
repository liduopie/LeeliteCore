using System;

namespace Leelite.Framework.Domain.Model
{
    /// <summary>
    /// 定义实体基本接口,系统中所有实体必须继承此接口。
    /// </summary>
    /// <typeparam name="TKey">实体的主键类型。</typeparam>
    public interface IEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 实体的唯一标识。
        /// </summary>
        TKey Id { get; set; }

        /// <summary>
        /// 检查该实体是暂时的 (没有保存到数据库，它没有 <see cref="Id"/>)。
        /// </summary>
        /// <returns>True, 该实体是暂时的。</returns>
        bool IsTransient();
    }
}
