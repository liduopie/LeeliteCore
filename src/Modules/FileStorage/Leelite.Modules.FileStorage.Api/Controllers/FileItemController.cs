using System;

using Leelite.Framework.WebApi;
using Leelite.Modules.FileStorage.Dtos.FileItemDtos;
using Leelite.Modules.FileStorage.Interfaces;
using Leelite.Modules.FileStorage.Models.FileItemAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Files.WebApi
{
    [ApiController]
    [Area("Files")]
    [Route("api/[area]/[controller]")]
    public class FileItemController : RESTfulController<FileItem, Guid, FileItemDto, FileItemCreateRequest, FileItemUpdateRequest, FileItemQueryParameter>
    {
        private readonly IFileItemService _service;

        public FileItemController(IFileItemService service) : base(service)
        {
            _service = service;
        }
    }
}