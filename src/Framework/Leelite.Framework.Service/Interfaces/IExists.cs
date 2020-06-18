using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Framework.Service.Interfaces
{
    public interface IExists<TKey>
    {
        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="ids">标识列表</param>
        bool Exists(params TKey[] ids);
    }
}
