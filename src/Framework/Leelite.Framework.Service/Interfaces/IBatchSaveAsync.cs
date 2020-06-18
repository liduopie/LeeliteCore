using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leelite.Framework.Service.Interfaces
{
    /// <summary>
    /// 批量保存操作
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    public interface IBatchSaveAsync<TDto>
    {
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="addList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        Task<IList<TDto>> SaveAsync(IList<TDto> addList, IList<TDto> updateList, IList<TDto> deleteList);
    }
}
