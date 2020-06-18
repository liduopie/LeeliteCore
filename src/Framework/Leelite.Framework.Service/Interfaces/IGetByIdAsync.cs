using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Leelite.Framework.Service.Dtos;

namespace Leelite.Framework.Service.Interfaces
{
    /// <summary>
    /// 获取指定标识实体
    /// </summary>
    public interface IGetByIdAsync<TDto, TKey>
        where TDto : IDto<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 通过编号获取
        /// </summary>
        /// <param name="id">实体编号</param>
        Task<TDto> GetByIdAsync(TKey id);

        /// <summary>
        /// 通过编号列表获取
        /// </summary>
        /// <param name="ids">用逗号分隔的Id列表，范例："1,2"</param>
        Task<IList<TDto>> GetByIdsAsync(IList<TKey> ids);
    }
}
