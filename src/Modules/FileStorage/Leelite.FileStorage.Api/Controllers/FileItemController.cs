using Leelite.FileStorage.Dtos.FileItemDtos;
using Leelite.FileStorage.Interfaces;
using Leelite.FileStorage.Models.FileItemAgg;
using Leelite.Framework.WebApi;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.FileStorage.Api
{
    [Area("Files")]
    public class FileItemController : RESTfulController<FileItem, Guid, FileItemDto, FileItemCreateRequest, FileItemUpdateRequest, FileItemQueryParameter>
    {
        private readonly IFileItemService _service;

        public FileItemController(IFileItemService service) : base(service)
        {
            _service = service;
        }
    }
}