using Coldairarrow.Util;
using HybridFS.FileStore.Options;

namespace HybridFS.FileStore.ShardingRule
{
    /// <summary>
    /// 数据库分库规则
    /// </summary>
    public class DbShardingRule
    {
        private readonly DbExpandByDateMode _mode;

        public DbShardingRule(DbExpandByDateMode mode)
        {
            _mode = mode;
        }

        /// <summary>
        /// 生成数据库名后缀
        /// </summary>
        /// <returns></returns>
        public string BuildDbSuffix(long id)
        {
            var sid = new SnowflakeId(id);

            switch (_mode)
            {
                case DbExpandByDateMode.PerMinute:
                    return sid.Time.ToString("yyyy-MM-dd-HH-mm");
                case DbExpandByDateMode.PerHour:
                    return sid.Time.ToString("yyyy-MM-dd-HH");
                case DbExpandByDateMode.PerDay:
                    return sid.Time.ToString("yyyy-MM-dd");
                case DbExpandByDateMode.PerMonth:
                    return sid.Time.ToString("yyyy-MM");
                case DbExpandByDateMode.PerYear:
                    return sid.Time.ToString("yyyy");
                default:
                    return string.Empty;
            }
        }

    }
}
