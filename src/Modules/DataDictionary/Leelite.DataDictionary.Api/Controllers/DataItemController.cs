using Leelite.DataDictionary.Dtos.DataItemDtos;
using Leelite.DataDictionary.Interfaces;
using Leelite.DataDictionary.Models.DataItemAgg;
using Leelite.Framework.WebApi;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.DataDictionary.Api
{
    [Area("DataDictionary")]
    public class DataItemController : RESTfulController<DataItem, int, DataItemDto, DataItemCreateRequest, DataItemUpdateRequest, DataItemQueryParameter>
    {
        private readonly IDataItemService _service;

        public DataItemController(IDataItemService service) : base(service)
        {
            _service = service;
        }
    }
}