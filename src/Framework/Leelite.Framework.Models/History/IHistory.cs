namespace Leelite.Framework.Models.History
{
    /// <summary>
    /// 实体历史记录
    /// </summary>
    public interface IHistory<TKey>
    {
        /// <summary>
        /// 历史记录
        /// </summary>
        IList<IHistoryRecord<TKey>> Histories { get; set; }
    }
}
