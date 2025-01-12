using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Models.CategoryTypeAgg;
using Leelite.Framework.Service;

namespace Leelite.DataCategory.Interfaces
{
    public interface ICategoryTypeService : ICrudService<CategoryType, int, CategoryTypeDto, CategoryTypeCreateRequest, CategoryTypeUpdateRequest, CategoryTypeQueryParameter>
    {
        /// <summary>
        /// 根据编码获取
        /// </summary>
        /// <param name="code">分类编码</param>
        /// <returns>分类信息</returns>
        CategoryTypeDto GetByCode(string code);

        /// <summary>
        /// 根据名称获取
        /// </summary>
        /// <param name="name">分类名称</param>
        /// <returns>分类信息</returns>
        CategoryTypeDto GetByName(string name);
    }
}
