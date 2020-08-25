namespace Leelite.Commons.Cache.BaseCache
{
    /// <summary>
    /// An upper level container for <see cref="IBaseCache"/> objects. 
    /// A cache manager should work as Singleton and track and manage <see cref="IBaseCache"/> objects.
    /// </summary>
    public interface IBaseCacheManager : ICacheManager<IBaseCache>
    {
    }
}
