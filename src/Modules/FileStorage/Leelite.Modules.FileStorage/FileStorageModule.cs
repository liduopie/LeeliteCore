using System;
using System.Threading.Tasks;

using Leelite.Commons.Host;
using Leelite.Core.Modular.Module;
using Leelite.Framework.Service.Commands;
using Leelite.Modules.FileStorage.CommandHandlers;
using Leelite.Modules.FileStorage.Contexts;
using Leelite.Modules.FileStorage.Models.FileItemAgg;
using Leelite.Modules.FileStorage.Dtos.FileItemDtos;
using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using HybridFS.FileSystem;

namespace Leelite.Modules.FileStorage
{
    public class FileStorageModule : ModuleStartupBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddDbContext<FileStorageContext>("Default");

            services.AddTransient<IRequestHandler<CreateCommand<FileItemCreateRequest, FileItemDto, FileItem, Guid>, FileItemDto>, FileInfoCreateCommandHandler>();

            services.AddHybridFS_Sqlite();
        }

        public override async Task UpdateDatabase()
        {
            var dbContext = HostManager.Context.HostServices.GetService<FileStorageContext>();

            await dbContext.Database.MigrateAsync();
        }
    }
}
