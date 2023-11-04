using System;

using Leelite.Core.Module;
using Leelite.Framework.Service.Commands;
using Leelite.FileStorage.CommandHandlers;
using Leelite.FileStorage.Contexts;
using Leelite.FileStorage.Dtos.FileItemDtos;
using Leelite.FileStorage.Models.FileItemAgg;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leelite.FileStorage
{
    public class FileStorageModule : ModuleBase
    {

        public override void ConfigureConventions()
        {
        }

        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FileStorageContext>("Default");

            services.AddTransient<IRequestHandler<CreateCommand<FileItemCreateRequest, FileItemDto, FileItem, Guid>, FileItemDto>, FileInfoCreateCommandHandler>();

            services.AddHybridFS_Sqlite();
        }
    }
}
