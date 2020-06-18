using System;

using Leelite.Framework.Service;
using Leelite.Modules.FileStorage.Dtos.FileItemDtos;
using Leelite.Modules.FileStorage.Models.FileItemAgg;

namespace Leelite.Modules.FileStorage.Interfaces
{
    public interface IFileItemService : ICrudService<FileItem, Guid, FileItemDto, FileItemCreateRequest, FileItemUpdateRequest, FileItemQueryParameter>
    {
    }
}
