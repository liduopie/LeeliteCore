using Leelite.DataCategory.Dtos.CategoryTypeDtos;
using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.Framework.Models.Tree;

namespace Leelite.Web.Models
{
    public class DataCategoryViewModel
    {
        public IList<CategoryTypeDto> CategoryTypes { get; set; }

        /// <summary>
        /// 激活的数据分类
        /// </summary>
        public CategoryTypeDto ActiveCategoryType { get; set; }

        public IList<ITreeNode<long, Category>> CategoryTree { get; set; }
    }
}
