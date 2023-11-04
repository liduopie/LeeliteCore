using System.Collections.Generic;
using Leelite.FileStorage.Models.FileItemAgg;

namespace Leelite.FileStorage.Options
{
    /// <summary>
    /// 文件存储选项
    /// </summary>
    public class FileStorageOptions
    {
        public IList<string> ModuleCodes { get; set; } = new List<string>();

        /// <summary>
        /// 根目录
        /// </summary>
        public string RootPath { get; set; } = "";

        /// <summary>
        /// 文件归类目录
        /// </summary>
        public IList<ClassifyOptions> ClassifyOptions { get; set; } = new List<ClassifyOptions>();

        /// <summary>
        /// 文件目录生成规则
        /// </summary>
        public DirectoryNameRule DirectoryRule { get; set; } = DirectoryNameRule.Day;

        /// <summary>
        /// 文件大小限制
        /// </summary>
        public long FileSizeLimit { get; set; } = 2097152;

        /// <summary>
        /// 上传文件的默认状态
        /// </summary>
        public FileState DefaultFileState = FileState.Reviewing;
    }
}
