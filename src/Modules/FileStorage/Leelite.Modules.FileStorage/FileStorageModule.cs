using System;
using System.Threading.Tasks;

using Leelite.Commons.Host;
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
using Leelite.Core.Module;

namespace Leelite.Modules.FileStorage
{
    public class FileStorageModule : ModuleBase
    {
        public override void ConfigureServices(HostContext context)
        {
            var services = context.ServiceDescriptors;

            services.AddDbContext<FileStorageContext>("Default");

            services.AddTransient<IRequestHandler<CreateCommand<FileItemCreateRequest, FileItemDto, FileItem, Guid>, FileItemDto>, FileInfoCreateCommandHandler>();

            services.AddHybridFS_Sqlite();
        }
    }
}
