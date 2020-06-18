using HybridFS.FileStore.Options;

namespace HybridFS
{
    public class HybridFSOptions
    {
        /// <summary>
        /// SnowflakeId 工作进程Id
        /// </summary>
        public int WorkderId { get; set; } = 1;

        /// <summary>
        /// 文件存储根目录
        /// </summary>
        public string RootPath { get; set; } = "HybridFS";

        /// <summary>
        /// 文件存储数据库名称
        /// </summary>
        public string FileStoreDbName { get; set; } = "FileDb";

        /// <summary>
        /// 文件系统数据库名称
        /// </summary>
        public string FileSystemDbName { get; set; } = "FileSys";

        /// <summary>
        /// 文件目录
        /// </summary>
        public string FilePath { get; set; } = "Files";

        /// <summary>
        /// 文件拆分到物理文件的大小
        /// </summary>
        public long SplitPhysicalFileSize { get; set; } = 2097152;

        /// <summary>
        /// 数据库扩容模式
        /// </summary>
        public DbExpandByDateMode ExpandMode { get; set; } = DbExpandByDateMode.PerMonth;

        /// <summary>
        /// 目录层级模式
        /// </summary>
        public DirectoryDepthMode DepthMode { get; set; } = DirectoryDepthMode.Month;
    }
}
