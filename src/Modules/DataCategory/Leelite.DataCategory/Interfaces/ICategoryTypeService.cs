using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Models.CategoryTypeAgg;
using Leelite.Framework.Service;

namespace Leelite.DataCategory.Interfaces
{
    public interface ICategoryTypeService : ICrudService<CategoryType, int, CategoryTypeDto, CategoryTypeCreateRequest, CategoryTypeUpdateRequest, CategoryTypeQueryParameter>
    {
    }
}
