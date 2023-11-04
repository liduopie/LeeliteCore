using System;

using Leelite.Framework.WebApi;
using Leelite.FileStorage.Dtos.FileItemDtos;
using Leelite.FileStorage.Interfaces;
using Leelite.FileStorage.Models.FileItemAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Files.WebApi
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