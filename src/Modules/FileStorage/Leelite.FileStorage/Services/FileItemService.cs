using System;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.FileStorage.Dtos.FileItemDtos;
using Leelite.FileStorage.Interfaces;
using Leelite.FileStorage.Models.FileItemAgg;
using Leelite.FileStorage.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.FileStorage.Services
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
