
using HybridFS.FileSystem;
using HybridFS.FileSystem.Models;

using Microsoft.Extensions.FileProviders;

namespace HybridFS.FileProvider
{
    public class HybridFSFileInfo : IFileInfo
    {
        private readonly IFileManager _manager;
        private readonly FileIndex? _index;
        private bool? exists;

        public HybridFSFileInfo(IFileManager manager, string path)
        {
            _manager = manager;

            _index = _manager.GetFileIndexAsync(path).GetAwaiter().GetResult();
        }

        public HybridFSFileInfo(IFileManager manager, FileIndex index)
        {
            _manager = manager;
            _index = index;
        }

        public bool Exists
        {
            get
            {
                if (!exists.HasValue)
                {
                    if (_index == null)
                        exists = false;
                    else
                        exists = true;
                }
                return exists.Value;
            }
        }

        public long Length => _index!.Length;

        public string PhysicalPath => _index!.Path;

        public string Name => _index!.Name;

        public DateTimeOffset LastModified => _index!.LastModifiedUtc;

        public bool IsDirectory => _index!.IsDirectory;

        public Stream? CreateReadStream()
        {
            if (_index != null && !IsDirectory)
                return _manager.GetFileStreamAsync(_index.Path).GetAwaiter().GetResult();
            return null;
        }
    }
}
