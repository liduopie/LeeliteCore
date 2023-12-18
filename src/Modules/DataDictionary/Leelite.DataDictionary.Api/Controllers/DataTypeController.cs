using Leelite.DataDictionary.Dtos.DataTypeDtos;
using Leelite.DataDictionary.Interfaces;
using Leelite.DataDictionary.Models.DataTypeAgg;
using Leelite.Framework.WebApi;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.DataDictionary.Api
{
    [Area("DataDictionary")]
    public class DataTypeController : RESTfulController<DataType, string, DataTypeDto, DataTypeCreateRequest, DataTypeUpdateRequest, DataTypeQueryParameter>
    {
        private readonly IDataTypeService _service;

        public DataTypeController(IDataTypeService service) : base(service)
        {
            _service = service;
        }
    }
}