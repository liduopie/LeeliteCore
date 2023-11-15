using Leelite.Framework.Service.Dtos;

namespace Leelite.DataCategory.Dtos.CategoryTypeDtos
{
    public class CategoryTypeUpdateRequest : IUpdateRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
