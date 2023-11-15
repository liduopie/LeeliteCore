using Leelite.DataDictionary.Models.DataTypeAgg;
using Leelite.Framework.Service.Dtos;

namespace Leelite.DataDictionary.Dtos.DataTypeDtos
{
    public class DataTypeCreateRequest : IRequest
    {
        public string Name { get; set; }

        public OwnerType OwnerType { get; set; }

    }
}
