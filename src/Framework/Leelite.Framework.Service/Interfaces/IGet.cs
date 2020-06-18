using System.Collections.Generic;
using Leelite.Framework.Data.Query.Parameters;

namespace Leelite.Framework.Service.Interfaces
{
    public interface IGet<TEntity, TDto, TParameter>
        where TParameter : GenericParameter<TEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        IList<TDto> Get(TParameter parameter);
    }
}
