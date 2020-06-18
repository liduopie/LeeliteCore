using System;
using System.Linq;

using HybridFS.FileSystem;

using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace HybridFS.FileProvider
{
    public class HybridFSFileProvider : IFileProvider
    {
        private static readonly char[] pathSeparators = new[] { '/' };

        private static readonly char[] invalidFileNameChars = new[] { '\\', '{', '}', '^', '%', '`', '[', ']', '\'', '"', '>', '<', '~', '#', '|' }
                                                              .Concat(Enumerable.Range(128, 255).Select(x => (char)x))
                                                              .ToArray();

        private readonly IFileManager _manager;

        public HybridFSFileProvider(IFileManager manager)
        {
            _manager = manager;
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            if (subpath == null) throw new ArgumentNullException(nameof(subpath));
            if (HasInvalidFileNameChars(subpath)) return NotFoundDirectoryContents.Singleton;

            // Relative paths starting with leading slashes are okay
            subpath = subpath.TrimStart(pathSeparators);

            return new HybridFSDirectoryContents(_manager, subpath);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            if (subpath == null) throw new ArgumentNullException(nameof(subpath));
            if (HasInvalidFileNameChars(subpath)) return new NotFoundFileInfo(subpath);

            // Relative paths starting with leading slashes are okay
            subpath = subpath.TrimStart(pathSeparators);

            if (string.IsNullOrEmpty(subpath))
                return new NotFoundFileInfo(subpath);

            return new HybridFSFileInfo(_manager, subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return NullChangeToken.Singleton;
        }

        private bool HasInvalidFileNameChars(string path)
        {
            return path.IndexOfAny(invalidFileNameChars) != -1;
        }
    }
}
