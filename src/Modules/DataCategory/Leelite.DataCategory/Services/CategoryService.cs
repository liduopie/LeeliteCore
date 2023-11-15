using Leelite.DataCategory.Dtos.CategoryDtos;
using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.DataCategory.Repositories;
using Leelite.DataCategory.Interfaces;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;

using Microsoft.Extensions.Logging;
using Leelite.Framework.Models.Tree;

namespace Leelite.DataCategory.Services
{
    public class CategoryService : CrudService<Category, long, CategoryDto, CategoryCreateRequest, CategoryUpdateRequest, CategoryQueryParameter>, ICategoryService
    {
        public CategoryService(
            ICategoryRepository repository,
            ICommandBus commandBus,
            ILogger<CategoryService> logger
            ) : base(repository, commandBus, logger)
        {
        }

        /// <inheritdoc/>
        public IList<ITreeNode<long>> GetCategoryTreeByType(int typeId)
        {
            var query = new CategoryQueryParameter();
            query.CategoryTypeId = typeId;
            query.ParentId = 0;

            var roots = Get(query);

            var nodes = new List<ITreeNode<long>>();

            foreach (var item in roots)
            {
                nodes.Add(this.GetTree(item.Id));
            }

            return nodes;
        }

        /// <inheritdoc/>
        public async Task<IList<ITreeNode<long>>> GetCategoryTreeByTypeAsync(int typeId)
        {
            var query = new CategoryQueryParameter();
            query.CategoryTypeId = typeId;

            var roots = await GetAsync(query);

            var nodes = new List<ITreeNode<long>>();

            foreach (var item in roots)
            {
                nodes.Add(await this.GetTreeAsync(item.Id));
            }

            return nodes;
        }
    }
}
