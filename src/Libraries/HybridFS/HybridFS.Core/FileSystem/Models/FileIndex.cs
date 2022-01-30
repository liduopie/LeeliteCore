namespace HybridFS.FileSystem.Models
{
    public class FileIndex
    {
        /// <summary>
        /// id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 完整路径
        /// </summary>
        public string Path { get; set; } = "";

        /// <summary>
        /// 所在文件夹路径
        /// </summary>
        public string DirectoryPath { get; set; } = "";

        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 扩展名
        /// </summary>
        public string Extension { get; set; } = "";

        /// <summary>
        /// 内容大小
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// MD5
        /// </summary>
        public string MD5 { get; set; } = "";

        /// <summary>
        /// 文件存储Id
        /// </summary>
        public long FileEntryId { get; set; }

        /// <summary>
        /// 是文件夹
        /// </summary>
        public bool IsDirectory { get; set; }

        /// <summary>
        /// 文件最后修改时间
        /// </summary>
        public DateTime LastModifiedUtc { get; set; }

        /// <summary>
        /// 访问次数
        /// </summary>
        public long Visits { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastVisitTimeUtc { get; set; }
    }
}
