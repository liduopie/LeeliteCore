using Leelite.DataDictionary.Dtos.DataItemDtos;
using Leelite.DataDictionary.Models.DataItemAgg;
using Leelite.Framework.Service;

namespace Leelite.DataDictionary.Interfaces
{
    public interface IDataItemService : ICrudService<DataItem, int, DataItemDto, DataItemCreateRequest, DataItemUpdateRequest, DataItemQueryParameter>
    {
    }
}
