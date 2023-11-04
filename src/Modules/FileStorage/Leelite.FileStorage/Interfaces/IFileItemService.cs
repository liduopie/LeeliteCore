using System;

using Leelite.Framework.Service;
using Leelite.FileStorage.Dtos.FileItemDtos;
using Leelite.FileStorage.Models.FileItemAgg;

namespace Leelite.FileStorage.Interfaces
{
    public interface IFileItemService : ICrudService<FileItem, Guid, FileItemDto, FileItemCreateRequest, FileItemUpdateRequest, FileItemQueryParameter>
    {
    }
}
