namespace Leelite.Framework.Models.Enabled
{
    /// <summary>
    /// 启用/禁用
    /// </summary>
    public interface IEnabled
    {
        /// <summary>
        /// 启用状态
        /// </summary>
        bool IsEnabled { get; set; }
    }
}
