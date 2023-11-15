using Leelite.Framework.Service.Dtos;

namespace Leelite.DataCategory.Dtos.CategoryDtos
{
    public class CategoryDto : IDto<long>
    {
        public long Id { get; set; }

        public int CategoryTypeId { get; set; }

        public string Code { get; set; }

        public string Icon { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ParentId { get; set; }

        public string Path { get; set; }

        public int Level { get; set; }

        public int Sort { get; set; }

        public bool IsLeaf { get; set; }

        public int ChildrenCount { get; set; }

        public bool IsEnabled { get; set; }
    }
}
