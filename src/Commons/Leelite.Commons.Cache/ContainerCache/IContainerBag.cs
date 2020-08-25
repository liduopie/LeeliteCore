using System;

namespace Leelite.Commons.Cache.ContainerCache
{
    /// <summary>
    /// ContainerCache中的Value基础类型
    /// </summary>
    public interface IContainerBag : ICacheOptions
    {
        /// <summary>
        /// 用于标记，方便后台管理
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 缓存键，形如：wx669ef95216eef885，最底层的Key，不考虑命名空间等
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// 当前对象被缓存的时间
        /// </summary>
        DateTimeOffset CacheTime { get; set; }
    }
}
