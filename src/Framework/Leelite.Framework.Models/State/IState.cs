namespace Leelite.Framework.Models.State
{
    /// <summary>
    /// 状态模式
    /// </summary>
    /// <typeparam name="TState"></typeparam>
    public interface IState<TState>
    {
        TState State { get; set; }
    }
}
