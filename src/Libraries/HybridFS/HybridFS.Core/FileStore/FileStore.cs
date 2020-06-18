using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using HybridFS.FileStore.Contexts;
using HybridFS.FileStore.Models;
using HybridFS.FileStore.ShardingRule;

namespace HybridFS.FileStore
{
    public class FileStore : IFileStore, IFileStoreCache
    {
        private readonly HybridFSOptions _options;
        private readonly IFileStoreContextFactory _factory;

        public FileStore(HybridFSOptions options, IFileStoreContextFactory factory)
        {
            _options = options;
            _factory = factory;
        }

        public async Task<FileEntry> CreateFileFromStreamAsync(Stream inputStream)
        {
            if (inputStream.Length == 0) return null;

            var entry = FileEntryFactory.CreateFileEntryByStream(inputStream);

            if (inputStream.Length > _options.SplitPhysicalFileSize)
            {

                var rule = new DirectoryShardingRule(_options.DepthMode);
                string filePath;
                do
                {
                    var trustedFileNameForFileStorage = Path.GetRandomFileName();

                    filePath = Path.Combine(
                       _options.RootPath,
                       _options.FilePath,
                       rule.BuildDirectoryPath(entry.Id),
                       trustedFileNameForFileStorage);
                } while (File.Exists(filePath));

                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var fileStream = File.Create(filePath))
                {
                    inputStream.Position = 0;
                    await inputStream.CopyToAsync(fileStream);
                }

                entry.PhysicalPath = filePath;
            }
            else
            {
                inputStream.Position = 0;
                entry.Content = new byte[inputStream.Length];

                inputStream.Read(entry.Content, 0, (int)inputStream.Length);
            }

            // 保存文件条目
            var context = _factory.GetContext(entry.Id);

            context.FileEntries.Add(entry);

            await context.SaveChangesAsync();

            return entry;
        }

        public async Task<FileEntry> GetFileEntryAsync(long id)
        {
            var context = _factory.GetContext(id);

            return await context.FileEntries.FindAsync(id);
        }

        public Task<Stream> GetFileStreamAsync(FileEntry fileEntry)
        {
            if (string.IsNullOrEmpty(fileEntry.PhysicalPath))
            {
                Stream output = new MemoryStream(fileEntry.Content);
                return Task.FromResult(output);
            }
            else
            {
                Stream output = File.Create(fileEntry.PhysicalPath);
                return Task.FromResult(output);
            }
        }

        public async Task<Stream> GetFileStreamAsync(long id)
        {
            var entry = await GetFileEntryAsync(id);

            return await GetFileStreamAsync(entry);
        }

        public async Task<bool> TryDeleteFileEntryAsync(long id)
        {
            try
            {
                var context = _factory.GetContext(id);

                var entry = await context.FileEntries.FindAsync(id);

                if (entry == null)
                    return true;

                entry.ReferenceCount--;

                if (entry.ReferenceCount <= 0)
                {
                    if (!string.IsNullOrEmpty(entry.PhysicalPath))
                    {
                        File.Delete(entry.PhysicalPath);
                    }

                    context.FileEntries.Remove(entry);
                }

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<bool> IsCachedAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task SetCacheAsync(Stream stream, FileEntry fileStoreEntry, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
