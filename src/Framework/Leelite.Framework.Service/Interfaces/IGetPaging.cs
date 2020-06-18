using System.Collections.Generic;
using Leelite.Framework.Data.Query.Paging;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.Framework.Service.Interfaces
{
    /// <summary>
    /// 分页查询
    /// </summary>   
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TPageParameter">查询参数类型</typeparam>
    public interface IGetPaging<TEntity, TDto, TPageParameter>
        where TPageParameter : PageParameter<TEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        IList<TDto> GetPage(TPageParameter parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        PageList<TDto> GetPageList(TPageParameter parameter);
    }
}
