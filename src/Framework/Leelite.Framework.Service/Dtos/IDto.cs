using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Framework.Service.Dtos
{
    /// <summary>
    /// 数据传输模型
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IDto<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 实体的唯一标识。
        /// </summary>
        TKey Id { get; set; }
    }
}
