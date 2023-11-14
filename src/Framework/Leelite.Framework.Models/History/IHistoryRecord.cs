using Leelite.Framework.Domain.Aggregate;

namespace Leelite.Framework.Models.History
{
    public interface IHistoryRecord<TKey> : IAggregateRoot<long>
    {
        /// <summary>
        /// 数据Id
        /// </summary>
        TKey DataId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime ModificationTime { get; set; }

        /// <summary>
        /// 修改人标识
        /// </summary>
        string ModifierId { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        string Modifier { get; set; }

        /// <summary>
        /// 修改前的数据
        /// </summary>
        string OriginalData { get; set; }

        /// <summary>
        /// 修改后的数据
        /// </summary>
        string NewData { get; set; }

        /// <summary>
        /// 修改摘要
        /// </summary>
        string Summary { get; set; }
    }
}
