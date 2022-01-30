using System.IO;
using System.Threading.Tasks;
using HybridFS.FileStore.Models;

namespace HybridFS.FileStore
{
    /// <summary>
    /// 文件条目存储
    /// </summary>
    public interface IFileStore
    {
        /// <summary>
        /// 通过Id获取文件条目
        /// </summary>
        /// <param name="id">文件Id</param>
        /// <returns>返回文件条目信息</returns>
        Task<FileEntry?> GetFileEntryAsync(long id);

        /// <summary>
        /// 根据文件条目Id获取文件流
        /// </summary>
        /// <param name="id">文件Id</param>
        /// <returns>返回文件流</returns>
        Task<Stream> GetFileStreamAsync(long id);

        /// <summary>
        /// 根据文件条目获取文件流
        /// </summary>
        /// <param name="fileEntry">文件条目信息</param>
        /// <returns>返回文件流</returns>
        Task<Stream> GetFileStreamAsync(FileEntry fileEntry);

        /// <summary>
        /// 根据文件流创建文件条目
        /// </summary>
        /// <param name="inputStream">输入文件流</param>
        /// <returns>返回文件条目Id</returns>
        Task<FileEntry?> CreateFileFromStreamAsync(Stream inputStream);

        /// <summary>
        /// 检查并删除文件条目
        /// </summary>
        /// <param name="id">文件条目Id</param>
        /// <returns>返回文件是否删除成功，如果不存在返回true。</returns>
        Task<bool> TryDeleteFileEntryAsync(long id);
    }
}
