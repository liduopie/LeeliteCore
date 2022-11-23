using System;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.FileStorage.Dtos.FileItemDtos;
using Leelite.Modules.FileStorage.Interfaces;
using Leelite.Modules.FileStorage.Models.FileItemAgg;
using Leelite.Modules.FileStorage.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.FileStorage.Services
{
    public class FileItemService : CrudService<FileItem, Guid, FileItemDto, FileItemCreateRequest, FileItemUpdateRequest, FileItemQueryParameter>, IFileItemService
    {
        public FileItemService(
            IFileInfoRepository repository,
            ICommandBus commandBus,
            ILogger<FileItemService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
