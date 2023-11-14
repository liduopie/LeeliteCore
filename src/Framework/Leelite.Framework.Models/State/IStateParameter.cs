namespace Leelite.Framework.Models.State
{
    public interface IStateParameter<TState>
    {
        /// <summary>
        /// 修改人标识
        /// </summary>
        TState State { get; set; }
    }
}
