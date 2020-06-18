using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using HybridFS.FileSystem;
using HybridFS.FileSystem.Models;

using Microsoft.Extensions.FileProviders;

namespace HybridFS.FileProvider
{
    public class HybridFSDirectoryContents : IDirectoryContents
    {
        private readonly IFileManager _manager;
        private readonly string _path;
        private readonly HybridDirectoryInfo _dirInfo;

        private bool? exists;

        private IEnumerable<IFileInfo> contents;

        public HybridFSDirectoryContents(IFileManager manager, string path)
        {
            _manager = manager;
            _path = path;
            _dirInfo = _manager.GetDirectoryInfoAsync(_path).GetAwaiter().GetResult();
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
                EnumerateContents();
            return contents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (contents == null)
                EnumerateContents();
            return contents.GetEnumerator();
        }

        private void EnumerateContents()
        {
            var files = _manager.GetDirectoryContentAsync(_path).GetAwaiter().GetResult();

            contents = files.Select(c => new HybridFSFileInfo(_manager, c));
        }
    }
}
