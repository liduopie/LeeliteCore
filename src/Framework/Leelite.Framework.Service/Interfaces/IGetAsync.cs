using System.Collections.Generic;
using System.Threading.Tasks;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.Framework.Service.Interfaces
{
    /// <summary>
    /// 获取全部数据
    /// </summary>
    public interface IGetAsync<TEntity, TDto, TParameter>
        where TParameter : GenericParameter<TEntity>
    {
        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="parameter">查询参数</param>
        Task<IList<TDto>> GetAsync(TParameter parameter);
    }
}
