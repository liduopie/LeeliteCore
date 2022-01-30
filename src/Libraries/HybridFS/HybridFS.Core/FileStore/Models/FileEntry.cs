namespace HybridFS.FileStore.Models
{
    /// <summary>
    /// 文件条目
    /// </summary>
    public class FileEntry
    {
        /// <summary>
        /// 文件条目Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 文件长度
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// 文件MD5
        /// </summary>
        public string MD5 { get; set; } = "";

        /// <summary>
        /// 文件引用次数
        /// </summary>
        public int ReferenceCount { get; set; }

        /// <summary>
        /// 文件创建时间
        /// </summary>
        public DateTime CreationTimeUtc { get; set; }

        /// <summary>
        /// 文件被访问次数
        /// </summary>
        public long Visits { get; set; }

        /// <summary>
        /// 文件被访问时间
        /// </summary>
        public DateTime? LastVisitTimeUtc { get; set; }

        /// <summary>
        /// 文件内容
        /// </summary>
        public byte[] Content { get; set; } = new byte[0];

        /// <summary>
        /// 文件物理路径
        /// </summary>
        public string PhysicalPath { get; set; } = "";
    }
}
