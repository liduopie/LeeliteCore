using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

using Coldairarrow.Util;

using HybridFS.FileStore;
using HybridFS.FileSystem.Contexts;
using HybridFS.FileSystem.Exceptions;
using HybridFS.FileSystem.Models;
using HybridFS.Utility;
using Microsoft.EntityFrameworkCore;

namespace HybridFS.FileSystem
{
    /// <inheritdoc/>
    public class FileManager : IFileManager
    {
        private readonly FileSystemContext _context;
        private readonly IFileStore _store;

        public FileManager(FileSystemContext context, IFileStore store)
        {
            _context = context;
            _store = store;
        }

        /// <inheritdoc/>
        public async Task<FileIndex> GetFileIndexAsync(string path)
        {
            return await _context.FileIndexs.Where(c => c.Path == path).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<HybridFileInfo> GetFileInfoAsync(string path)
        {
            var index = await _context.FileIndexs.Where(c => c.Path == path).FirstOrDefaultAsync();

            if (index == null) return null;

            return index.ToFileInfo();
        }

        /// <inheritdoc/>
        public async Task<HybridDirectoryInfo> GetDirectoryInfoAsync(string path)
        {
            var index = await _context.FileIndexs.Where(c => c.Path == path).FirstOrDefaultAsync();

            if (index == null) return null;

            return index.ToDirectoryInfo();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<FileIndex>> GetDirectoryContentAsync(string path = null, bool includeSubDirectories = false)
        {
            if (includeSubDirectories)
            {
                var files = from c in _context.FileIndexs
                            where c.DirectoryPath.StartsWith(path)
                            select c;

                return await files.ToListAsync();
            }
            else
            {
                var files = from c in _context.FileIndexs
                            where c.IsDirectory == false && c.DirectoryPath == path
                            select c;

                return await files.ToListAsync();
            }
        }

        /// <inheritdoc/>
        public async Task<Stream> GetFileStreamAsync(string path)
        {
            if (string.IsNullOrEmpty(path)) return null;

            var index = await _context.FileIndexs.Where(c => c.Path == path).FirstOrDefaultAsync();

            if (index == null) return null;

            return await _store.GetFileStreamAsync(index.FileEntryId);
        }

        /// <inheritdoc/>
        public async Task<bool> TryCreateDirectoryAsync(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path)) return true;

                // 检查文件夹记录是否完整
                var index = await _context.FileIndexs.Where(c => c.Path == path).FirstOrDefaultAsync();

                if (index != null) return true;

                index = new FileIndex();

                index.Id = IdHelper.GetLongId();
                index.Path = PathHelper.NormalizePath(path);
                index.DirectoryPath = PathHelper.NormalizePath(Path.GetDirectoryName(path));
                index.IsDirectory = true;

                var nowTime = DateTime.UtcNow;
                index.LastModifiedUtc = nowTime;
                index.Visits = 0;
                index.LastVisitTimeUtc = nowTime;

                _context.FileIndexs.Add(index);

                await _context.SaveChangesAsync();

                await TryCreateDirectoryAsync(index.DirectoryPath);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <inheritdoc/>
        public async Task<HybridFileInfo> CreateFileFromStreamAsync(string path, Stream inputStream, bool overwrite = false)
        {
            // 检查文件夹记录是否完整
            var index = await _context.FileIndexs.Where(c => c.Path == path).FirstOrDefaultAsync();
            if (index != null && overwrite == false) throw new FileHasExistedException("同名文件已经存在!", path);

            // 创建文件记录
            if (index == null) index = new FileIndex();

            index.Id = IdHelper.GetLongId();
            index.Path = PathHelper.NormalizePath(path);
            index.DirectoryPath = PathHelper.NormalizePath(Path.GetDirectoryName(path));

            // 检查并创建目录
            await TryCreateDirectoryAsync(index.DirectoryPath);

            index.Name = Path.GetFileName(path);
            index.Extension = Path.GetExtension(path);
            index.Length = inputStream.Length;
            index.IsDirectory = false;

            var nowTime = DateTime.UtcNow;
            index.LastModifiedUtc = nowTime;
            index.Visits = 0;
            index.LastVisitTimeUtc = nowTime;

            var md5 = GetStreamMD5(inputStream);
            var file = await (from c in _context.FileIndexs
                              where c.MD5 == md5 && c.Length == inputStream.Length
                              select c).FirstOrDefaultAsync();
            if (file == null)
            {

                // 把文件流交给文件存储保存
                var entry = await _store.CreateFileFromStreamAsync(inputStream);

                index.MD5 = entry.MD5;
                index.FileEntryId = entry.Id;
            }
            else
            {
                index.MD5 = file.MD5;
                index.FileEntryId = file.Id;
            }

            _context.FileIndexs.Add(index);

            await _context.SaveChangesAsync();

            return index.ToFileInfo();
        }

        /// <inheritdoc/>
        public async Task<bool> TryDeleteDirectoryAsync(string path)
        {
            try
            {
                var indexs = _context.FileIndexs.Where(c => c.Path.StartsWith(path)).OrderByDescending(c => c.Path);

                foreach (var item in indexs)
                {
                    _context.FileIndexs.Remove(item);

                    await _store.TryDeleteFileEntryAsync(item.FileEntryId);
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> TryDeleteFileAsync(string path)
        {
            try
            {
                // 检查文件夹记录是否完整
                var index = await _context.FileIndexs.Where(c => c.Path == path).FirstOrDefaultAsync();

                if (index == null) return true;

                _context.FileIndexs.Remove(index);

                await _context.SaveChangesAsync();

                await _store.TryDeleteFileEntryAsync(index.FileEntryId);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task CopyFileAsync(string srcPath, string dstPath)
        {
            var src = await _context.FileIndexs.Where(c => c.Path == srcPath).FirstOrDefaultAsync();

            if (src == null) return;

            var dst = new FileIndex();

            dst.Id = IdHelper.GetLongId();
            dst.Path = PathHelper.NormalizePath(dstPath);
            dst.DirectoryPath = PathHelper.NormalizePath(Path.GetDirectoryName(dstPath));

            // 检查并创建目录
            await TryCreateDirectoryAsync(dst.DirectoryPath);

            dst.Name = Path.GetFileName(dstPath);
            dst.Extension = Path.GetExtension(dstPath);
            dst.Length = src.Length;
            dst.IsDirectory = false;

            var nowTime = DateTime.UtcNow;
            dst.LastModifiedUtc = nowTime;
            dst.Visits = 0;
            dst.LastVisitTimeUtc = nowTime;

            dst.MD5 = src.MD5;
            dst.FileEntryId = src.Id;

            _context.FileIndexs.Add(dst);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task MoveFileAsync(string oldPath, string newPath)
        {
            var index = await _context.FileIndexs.Where(c => c.Path == oldPath).FirstOrDefaultAsync();

            index.Path = PathHelper.NormalizePath(newPath);
            index.DirectoryPath = PathHelper.NormalizePath(Path.GetDirectoryName(newPath));

            await _context.SaveChangesAsync();
        }

        private string GetStreamMD5(Stream stream)
        {
            string fileMD5;
            using (MD5 md5 = MD5.Create())
            {
                stream.Position = 0;
                //开始加密
                byte[] output = md5.ComputeHash(stream);

                fileMD5 = BitConverter.ToString(output).Replace("-", "");
            }

            return fileMD5;
        }
    }
}
