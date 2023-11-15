using Leelite.Framework.Service.Dtos;

namespace Leelite.DataCategory.Dtos.CategoryDtos
{
    public class CategoryCreateRequest : IRequest
    {
        public int CategoryTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public int Sort { get; set; }
    }
}
