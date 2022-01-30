using System;
using Coldairarrow.Util;
using HybridFS;
using HybridFS.FileStore;
using HybridFS.FileSystem;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class HybridFSServiceCollectionExtensions
    {
        public static void AddHybridFS(this IServiceCollection service, Action<HybridFSOptions>? action = null)
        {

            var options = new HybridFSOptions();

            action?.Invoke(options);

            service.AddSingleton(options);

            new IdHelperBootstrapper()
                //设置WorkerId
                .SetWorkderId(options.WorkderId)
                .Boot();

            service.AddSingleton<IFileStore, FileStore>();

            service.AddSingleton<IFileManager, FileManager>();
        }
    }
}
