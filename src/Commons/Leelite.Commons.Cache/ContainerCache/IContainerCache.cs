namespace Leelite.Commons.Cache.ContainerCache
{
    /// <summary>
    /// 容器缓存接口
    /// </summary>
    public interface IContainerCache<TKey, TValue> : ICache<TKey, TValue> where TValue : IContainerBag
    {
    }
}
