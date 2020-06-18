using System;

namespace Leelite.Framework.Service.Dtos
{
    /// <summary>
    /// 更新请求
    /// </summary>
    /// <typeparam name="TKey">实体主键</typeparam>
    public interface IUpdateRequest<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 实体的唯一标识。
        /// </summary>
        TKey Id { get; set; }
    }
}
