using AutoMapper;

using Leelite.DataCategory.Dtos.CategoryDtos;
using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.DataCategory.Models.CategoryTypeAgg;

namespace Leelite.DataCategory
{
    public class DataCategoryProfile : Profile
    {
        public DataCategoryProfile()
        {
            // Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateRequest, Category>();
            CreateMap<CategoryUpdateRequest, Category>();

            // CategoryType
            CreateMap<CategoryType, CategoryTypeDto>();
            CreateMap<CategoryTypeCreateRequest, CategoryType>();
            CreateMap<CategoryTypeUpdateRequest, CategoryType>();
        }
    }
}
