using System;

namespace Leelite.Commons.Cache
{
    public interface ICacheOptions
    {
        /// <summary>
        /// Default sliding expire time of cache items.
        /// Default value: 60 minutes (1 hour).
        /// Can be changed by configuration.
        /// </summary>
        TimeSpan DefaultSlidingExpireTime { get; set; }

        /// <summary>
        /// Default absolute expire time of cache items.
        /// Default value: null (not used).
        /// </summary>
        TimeSpan? DefaultAbsoluteExpireTime { get; set; }
    }
}
