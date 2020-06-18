using System.IO;
using System.Threading;
using System.Threading.Tasks;
using HybridFS.FileStore.Models;

namespace HybridFS.FileStore
{
    /// <summary>
    /// 文件存储缓存
    /// </summary>
    public interface IFileStoreCache
    {
        Task<bool> IsCachedAsync(long id);
        Task SetCacheAsync(Stream stream, FileEntry fileEntry, CancellationToken cancellationToken);
    }
}
