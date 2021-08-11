namespace Leelite.Modules.MessageCenter.Models.SessionAgg
{
    public enum CompleteState
    {
        /// <summary>
        /// 等待中
        /// </summary>
        Waiting,
        /// <summary>
        /// 推送中
        /// </summary>
        Pushing,
        /// <summary>
        /// 已完成
        /// </summary>
        Completed,
        /// <summary>
        /// 已停止
        /// </summary>
        Stoped
    }
}
