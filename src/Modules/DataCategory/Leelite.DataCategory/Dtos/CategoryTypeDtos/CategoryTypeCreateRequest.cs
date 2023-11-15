using Leelite.Framework.Service.Dtos;

namespace Leelite.DataCategory.Dtos.CategoryTypeDtos
{
    public class CategoryTypeCreateRequest : IRequest
    {
        public string Name { get; set; }
    }
}
