using HybridFS.FileSystem.Models;

namespace HybridFS.FileSystem
{
    /// <summary>
    /// 文件系统管理器
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// 获取文件索引信息
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回文件索引信息，如果不存在返回null</returns>
        Task<FileIndex> GetFileIndexAsync(string path);

        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回文件信息，如果不存在返回null</returns>
        Task<HybridFileInfo> GetFileInfoAsync(string path);

        /// <summary>
        /// 返回文件夹信息
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <returns>返回文件夹信息，如果不存在返回null</returns>
        Task<HybridDirectoryInfo> GetDirectoryInfoAsync(string path);

        /// <summary>
        /// 获取文件夹内容
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="includeSubDirectories">是否包含子目录</param>
        /// <returns>返回文件夹中的文件</returns>
        Task<IEnumerable<FileIndex>> GetDirectoryContentAsync(string path, bool includeSubDirectories = false);


        /// <summary>
        /// 检查并创建文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <returns>返回是否创建成功，如果已经存在返回true。</returns>
        Task<bool> TryCreateDirectoryAsync(string path);

        /// <summary>
        /// 检查并删除文件夹
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <returns>返回是否删除成功，如果文件夹不存在返回ture。</returns>
        Task<bool> TryDeleteDirectoryAsync(string path);

        /// <summary>
        /// 根据文件流创建文件信息
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="inputStream">输入文件流</param>
        /// <param name="overwrite"><c>true</c>覆盖一个文件是否已经存在;如果文件已经存在，<c>false</c>抛出异常。</param>
        /// <returns>返回文件信息</returns>
        /// <remarks>
        /// 如果指定的路径包含一个或多个目录，则这些目录为
        /// 如果它们不存在，就创建它们。
        /// </remarks>
        Task<HybridFileInfo> CreateFileFromStreamAsync(string path, Stream inputStream, bool overwrite = false);

        /// <summary>
        /// 检查并删除文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回是否删除成功，如果文件不存在返回true。</returns>
        Task<bool> TryDeleteFileAsync(string path);

        /// <summary>
        /// 移动一个文件信息
        /// </summary>
        /// <param name="oldPath">旧路径</param>
        /// <param name="newPath">新路径</param>
        Task MoveFileAsync(string oldPath, string newPath);

        /// <summary>
        /// 复制一个文件信息
        /// </summary>
        /// <param name="srcPath">源路径</param>
        /// <param name="dstPath">目标路径</param>
        Task CopyFileAsync(string srcPath, string dstPath);

        /// <summary>
        /// 获取一个文件流
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>返回一个文件流</returns>
        Task<Stream> GetFileStreamAsync(string path);
    }
}
