using Leelite.Commons.Lifetime;
using Leelite.Framework.Data.Store.Operations;

namespace Leelite.Framework.Data.Store
{
    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IStore<T> : IQueryStore<T>,
        IAdd<T>,
        IAddAsync<T>,
        IRemove<T>,
        IRemoveAsync<T>,
        IUpdate<T>,
        IUpdateAsync<T>,
        IScope
    {
    }
}
