using Leelite.DataCategory.Dtos.CategoryDtos;
using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.Framework.Models.Tree;
using Leelite.Framework.Service;

namespace Leelite.DataCategory.Interfaces
{
    public interface ICategoryService : ICrudService<Category, long, CategoryDto, CategoryCreateRequest, CategoryUpdateRequest, CategoryQueryParameter>
    {
        /// <summary>
        /// 根据分类类别获取分类树
        /// </summary>
        /// <param name="typeId">分类Id</param>
        /// <param name="includeDisable">包含禁用</param>
        /// <returns>返回节点结合</returns>
        IList<ITreeNode<long, Category>> GetCategoryTreeByType(int typeId, bool includeDisable);

        /// <summary>
        /// 根据分类类别获取分类树
        /// </summary>
        /// <param name="typeId">分类Id</param>
        /// <param name="includeDisable">包含禁用</param>
        /// <returns>返回节点结合</returns>
        Task<IList<ITreeNode<long, Category>>> GetCategoryTreeByTypeAsync(int typeId, bool includeDisable);
    }
}
