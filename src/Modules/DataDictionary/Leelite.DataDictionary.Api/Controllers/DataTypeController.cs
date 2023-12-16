using Leelite.Framework.WebApi;
using Leelite.DataDictionary.Dtos.DataTypeDtos;
using Leelite.DataDictionary.Interfaces;
using Leelite.DataDictionary.Models.DataTypeAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.DataDictionary.Api
{
    [ApiController]
    [Area("DataDictionary")]
    [ApiExplorerSettings(GroupName = "manager")]
    [Route("api/[area]/[controller]")]
    public class DataTypeController : RESTfulController<DataType, string, DataTypeDto, DataTypeCreateRequest, DataTypeUpdateRequest, DataTypeQueryParameter>
    {
        private readonly IDataTypeService _service;

        public DataTypeController(IDataTypeService service) : base(service)
        {
            _service = service;
        }
    }
}