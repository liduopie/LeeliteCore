using Leelite.DataDictionary.Dtos.DataTypeDtos;
using Leelite.DataDictionary.Models.DataTypeAgg;
using Leelite.Framework.Service;

namespace Leelite.DataDictionary.Interfaces
{
    public interface IDataTypeService : ICrudService<DataType, string, DataTypeDto, DataTypeCreateRequest, DataTypeUpdateRequest, DataTypeQueryParameter>
    {
    }
}
