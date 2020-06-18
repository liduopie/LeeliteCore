using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Framework.Models.History
{
    /// <summary>
    /// 实体历史记录
    /// </summary>
    public interface IHistory
    {
        /// <summary>
        /// 历史记录
        /// </summary>
        IList<IHistoryRecord> Histories { get; set; }
    }
}
