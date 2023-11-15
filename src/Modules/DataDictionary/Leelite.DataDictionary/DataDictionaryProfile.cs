using AutoMapper;

using Leelite.DataDictionary.Dtos.DataItemDtos;
using Leelite.DataDictionary.Dtos.DataTypeDtos;
using Leelite.DataDictionary.Models.DataItemAgg;
using Leelite.DataDictionary.Models.DataTypeAgg;

namespace Leelite.DataDictionary
{
    public class DataDictionaryProfile : Profile
    {
        public DataDictionaryProfile()
        {
            // DataType
            CreateMap<DataType, DataTypeDto>();
            CreateMap<DataTypeCreateRequest, DataType>();
            CreateMap<DataTypeUpdateRequest, DataType>();

            // DataItem
            CreateMap<DataItem, DataItemDto>();
            CreateMap<DataItemCreateRequest, DataItem>();
            CreateMap<DataItemUpdateRequest, DataItem>();
        }
    }
}
