using Coldairarrow.Util;
using HybridFS.FileStore.Options;

namespace HybridFS.FileStore.ShardingRule
{
    /// <summary>
    /// 目录规则
    /// </summary>
    public class DirectoryShardingRule
    {
        private readonly DirectoryDepthMode _mode;

        public DirectoryShardingRule(DirectoryDepthMode mode)
        {
            _mode = mode;
        }

        /// <summary>
        /// 生成数据库名后缀
        /// </summary>
        /// <returns></returns>
        public string BuildDirectoryPath(long id)
        {
            var sid = new SnowflakeId(id);

            switch (_mode)
            {
                case DirectoryDepthMode.Minute:
                    return sid.Time.ToString("yyyy/yyyy-MM/yyyy-MM-dd-HH-mm");
                case DirectoryDepthMode.Hour:
                    return sid.Time.ToString("yyyy/yyyy-MM/yyyy-MM-dd-HH");
                case DirectoryDepthMode.Day:
                    return sid.Time.ToString("yyyy/yyyy-MM/yyyy-MM-dd");
                case DirectoryDepthMode.Month:
                    return sid.Time.ToString("yyyy/yyyy-MM");
                case DirectoryDepthMode.Year:
                    return sid.Time.ToString("yyyy");
                default:
                    return string.Empty;
            }
        }
    }
}
