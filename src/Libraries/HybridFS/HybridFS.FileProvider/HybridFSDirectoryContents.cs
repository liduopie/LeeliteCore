using HybridFS.FileSystem;
using HybridFS.FileSystem.Models;

using Microsoft.Extensions.FileProviders;

using System.Collections;

namespace HybridFS.FileProvider
{
    public class HybridFSDirectoryContents : IDirectoryContents
    {
        private readonly IFileManager _manager;
        private readonly string _path;
        private readonly HybridDirectoryInfo _dirInfo;

        private bool? exists;

        private IEnumerable<IFileInfo>? contents;

        public HybridFSDirectoryContents(IFileManager manager, string path)
        {
            _manager = manager;
            _path = path;
            _dirInfo = _manager.GetDirectoryInfoAsync(_path).GetAwaiter().GetResult()!;
        }

        public bool Exists
        {
            get
            {
                if (!exists.HasValue)
                {
                    try
                    {
                        if (_dirInfo == null)
                            exists = false;
                        else
                            exists = true;
                    }
                    catch (Exception)
                    {
                        exists = false;
                        throw;
                    }

                }
                return exists.Value;
            }
        }

        public IEnumerator<IFileInfo> GetEnumerator()
        {
            if (contents == null)
            {
                var files = _manager.GetDirectoryContentAsync(_path).GetAwaiter().GetResult();

                contents = files.Select(c => new HybridFSFileInfo(_manager, c));

                return contents.GetEnumerator();
            }

            return contents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
