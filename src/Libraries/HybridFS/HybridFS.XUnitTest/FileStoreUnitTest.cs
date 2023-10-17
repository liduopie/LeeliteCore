using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

using Coldairarrow.Util;
using HybridFS.FileStore;
using HybridFS.FileStore.Contexts;
using HybridFS.FileStore.Models;
using HybridFS.FileStore.Options;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace HybridFS.XUnitTest
{
    public class FileStoreUnitTest
    {
        public FileStoreUnitTest()
        {
            new IdHelperBootstrapper()
                //设置WorkerId
                .SetWorkderId(1)
                .Boot();
        }

        [Fact]
        public void AutoCreateDatabaseTest()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite(options =>
            {
                options.ExpandMode = DbExpandByDateMode.PerMinute;
            });

            var serviceProvider = services.BuildServiceProvider();

            var factory = serviceProvider.GetRequiredService<IFileStoreContextFactory>();

            var dbcontext = factory.GetContext(IdHelper.GetLongId());

            Assert.NotNull(dbcontext);
        }

        [Fact]
        public async Task AddEntryTest()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            var factory = serviceProvider.GetRequiredService<IFileStoreContextFactory>();

            var result = 0;

            for (int i = 0; i < 10; i++)
            {
                var id = IdHelper.GetLongId();

                var dbcontext = factory.GetContext(IdHelper.GetLongId());

                var entry = new FileEntry();
                entry.Id = id;

                dbcontext.FileEntries.Add(entry);

                await dbcontext.SaveChangesAsync();

                result++;
            }

            Assert.Equal(10, result);
        }

        [Fact]
        public async Task AddFileEntryTest()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            IFileStore store = serviceProvider.GetRequiredService<IFileStore>();

            var content = new byte[10000];
            FileEntry entry;
            using (var stream = new MemoryStream(content))
            {
                entry = await store.CreateFileFromStreamAsync(stream);
            }

            Assert.NotEqual(0, entry.Id);

            var file = await store.GetFileEntryAsync(entry.Id);

            Assert.Equal(content.Length, file.Length);
        }

        [Fact]
        public async Task AddBigFileEntryTest()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            IFileStore store = serviceProvider.GetRequiredService<IFileStore>();

            var content = new byte[12097152];
            FileEntry entry;
            using (var stream = new MemoryStream(content))
            {
                entry = await store.CreateFileFromStreamAsync(stream);
            }

            Assert.NotEqual(0, entry!.Id);

            var file = await store.GetFileEntryAsync(entry.Id);

            Assert.Equal(content.Length, file!.Length);
        }

        [Fact]
        public async Task AddRandomFileSizeTest()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            IFileStore store = serviceProvider.GetRequiredService<IFileStore>();

            Random rd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                var content = new byte[rd.Next(1, 97152)];
                FileEntry entry;
                using (var stream = new MemoryStream(content))
                {
                    entry = await store.CreateFileFromStreamAsync(stream);
                }
            }

            Assert.True(true);
        }

        [Fact]
        public async Task AutoShardinDatabaseTest()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite(options =>
            {
                options.ExpandMode = DbExpandByDateMode.PerMinute;
            });

            var serviceProvider = services.BuildServiceProvider();

            IFileStore store = serviceProvider.GetRequiredService<IFileStore>();

            for (int i = 0; i < 100; i++)
            {
                var content = new byte[10000];
                FileEntry entry;
                using (var stream = new MemoryStream(content))
                {
                    entry = await store.CreateFileFromStreamAsync(stream);
                }

                Thread.Sleep(1000);
            }
        }

        [Fact]
        public async Task DeleteFielTest()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            IFileStore store = serviceProvider.GetRequiredService<IFileStore>();

            Random rd = new Random();

            var content = new byte[rd.Next(1, 3097152)];
            FileEntry entry;
            using (var stream = new MemoryStream(content))
            {
                entry = await store.CreateFileFromStreamAsync(stream);
            }

            var file = await store.GetFileEntryAsync(entry.Id);

            Assert.Equal(content.Length, file.Length);

            await store.TryDeleteFileEntryAsync(entry.Id);

            var fileEntry = await store.GetFileEntryAsync(entry.Id);

            Assert.Null(fileEntry);
        }

        [Fact]
        public async Task FileMD5Test()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            IFileStore store = serviceProvider.GetRequiredService<IFileStore>();

            Random rand = new Random();

            var content = new byte[10000];

            rand.NextBytes(content);

            FileEntry entry;
            string filemd5;
            using (var stream = new MemoryStream(content))
            {
                using (MD5 md5 = MD5.Create())
                {
                    //开始加密
                    byte[] output = md5.ComputeHash(stream);

                    filemd5 = BitConverter.ToString(output).Replace("-", "");
                }

                entry = await store.CreateFileFromStreamAsync(stream);
            }

            Assert.NotEqual(0, entry.Id);

            var file = await store.GetFileEntryAsync(entry.Id);

            Assert.Equal(filemd5, file.MD5);
        }

    }
}
