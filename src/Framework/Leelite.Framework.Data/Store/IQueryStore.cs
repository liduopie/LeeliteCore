using Leelite.Framework.Data.Store.Operations;

namespace Leelite.Framework.Data.Store
{
    /// <summary>
    /// 查询存储器
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public interface IQueryStore<T> : IAbstractStore<T>,
        ICount<T>,
        ICountAsync<T>,
        IExists<T>,
        IExistsAsync<T>,
        IFind<T>,
        IFindAsync<T>
    {
    }
}
