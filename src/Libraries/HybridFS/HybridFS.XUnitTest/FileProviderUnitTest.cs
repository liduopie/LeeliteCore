using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HybridFS.FileProvider;
using HybridFS.FileSystem;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace HybridFS.XUnitTest
{
    public class FileProviderUnitTest
    {
        private IFileManager GetFileManager()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddHybridFS_Sqlite();

            var serviceProvider = services.BuildServiceProvider();

            var manager = serviceProvider.GetRequiredService<IFileManager>();

            return manager;
        }

        [Fact]
        public void HybridFS_GetFileAndCheckInformation()
        {
            var fileProvider = new HybridFSFileProvider(GetFileManager());
            var fileInfo = fileProvider.GetFileInfo(@"\FileMD5Test\arrraejl.adq");

            Assert.True(fileInfo.Exists);
            Assert.False(fileInfo.IsDirectory);
            Assert.Equal(Convert.ToDateTime("2020-05-20 08:28:45.1323675"), fileInfo.LastModified);
            Assert.Equal("arrraejl.adq", fileInfo.Name);
            Assert.Equal(@"\FileMD5Test\arrraejl.adq", fileInfo.PhysicalPath);
            Assert.Equal(2046431, fileInfo.Length);
        }

        [Fact]
        public void HybridFS_GetRootContents()
        {
            var fileProvider = new HybridFSFileProvider(GetFileManager());
            var folderInfo = fileProvider.GetDirectoryContents(@"\");

            Assert.True(folderInfo.Exists);
            Assert.Equal(2, folderInfo.Count());
            Assert.Contains(folderInfo, x => x.Name == "jcwyfhiq.3ls");
        }
    }
}
