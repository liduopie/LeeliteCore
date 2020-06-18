using System;
using System.Threading.Tasks;
using Leelite.Framework.Service.Dtos;

namespace Leelite.Framework.Service.Interfaces
{
    /// <summary>
    /// 修改操作
    /// </summary>
    /// <typeparam name="TUpdateRequest">修改参数类型</typeparam>
    public interface IUpdateAsync<TKey, TUpdateRequest, TDto>
        where TUpdateRequest : IUpdateRequest<TKey>
        where TKey : IEquatable<TKey>
        where TDto : IDto<TKey>
    {
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        Task<TDto> UpdateAsync(TUpdateRequest request);
    }
}
