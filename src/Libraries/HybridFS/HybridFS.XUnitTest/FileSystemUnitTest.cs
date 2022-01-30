using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Coldairarrow.Util;
using HybridFS.FileStore.Options;
using HybridFS.FileSystem;
using HybridFS.FileSystem.Contexts;
using HybridFS.FileSystem.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HybridFS.XUnitTest
{
    public class FileSystemUnitTest
    {
        public FileSystemUnitTest()
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

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            var dbcontext = serviceProvider.GetService<FileSystemContext>();

            Assert.NotNull(dbcontext);
        }

        [Fact]
        public async Task AddRandomFileSizeTest()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            var manager = serviceProvider.GetRequiredService<IFileManager>();

            Random rd = new Random();

            for (int i = 0; i < 3; i++)
            {
                var content = new byte[rd.Next(1, 4097152)];
                using (var stream = new MemoryStream(content))
                {
                    await manager.CreateFileFromStreamAsync(@"\RandomFileSizeTest\" + Path.GetRandomFileName(), stream);
                }
            }

            Assert.True(true);
        }

        [Fact]
        public async Task FileMD5Test()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            var manager = serviceProvider.GetRequiredService<IFileManager>();

            Random rand = new Random();

            var content = new byte[10000];

            rand.NextBytes(content);

            HybridFileInfo info;

            string filePath = @"\FileMD5Test\" + Path.GetRandomFileName();
            string filemd5;
            using (var stream = new MemoryStream(content))
            {
                using (MD5 md5 = MD5.Create())
                {
                    //开始加密
                    byte[] output = md5.ComputeHash(stream);

                    filemd5 = BitConverter.ToString(output).Replace("-", "");
                }

                info = await manager.CreateFileFromStreamAsync(filePath, stream);
            }

            Assert.NotEqual(0, info.Id);

            var file = await manager.GetFileInfoAsync(filePath);

            Assert.Equal(filemd5, file?.MD5);

            var ouputStream = await manager.GetFileStreamAsync(filePath);

            if (ouputStream == null) return;

            string outputmd5;
            using (MD5 md5 = MD5.Create())
            {
                //开始加密
                byte[] output = md5.ComputeHash(ouputStream);

                outputmd5 = BitConverter.ToString(output).Replace("-", "");
            }

            Assert.Equal(filemd5, outputmd5);
        }

        [Fact]
        public async Task DeleteFielTest()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            var manager = serviceProvider.GetRequiredService<IFileManager>();

            Random rd = new Random();

            var content = new byte[rd.Next(1, 3097152)];
            string filePath = @"\FileMD5Test\" + Path.GetRandomFileName();
            HybridFileInfo info;
            using (var stream = new MemoryStream(content))
            {
                info = await manager.CreateFileFromStreamAsync(filePath, stream);
            }

            await manager.TryDeleteFileAsync(filePath);

            var file = await manager.GetFileInfoAsync(filePath);

            Assert.Null(file);
        }
    }
}
