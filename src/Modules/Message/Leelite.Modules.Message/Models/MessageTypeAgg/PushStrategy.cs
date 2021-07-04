namespace Leelite.Modules.Message.Models.MessageTypeAgg
{
    public enum PushStrategy
    {
        /// <summary>
        /// 顺序推送，送达后停止后续平台推送
        /// </summary>
        Sequence,
        /// <summary>
        /// 全部推送
        /// </summary>
        All
    }
}
