using Leelite.DataCategory.Dtos.CategoryDtos;
using Leelite.DataCategory.Interfaces;
using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.DataCategory.Repositories;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Models.Tree;
using Leelite.Framework.Service;

using Microsoft.Extensions.Logging;

namespace Leelite.DataCategory.Services
{
    public class CategoryService : CrudService<Category, long, CategoryDto, CategoryCreateRequest, CategoryUpdateRequest, CategoryQueryParameter>, ICategoryService
    {
        public CategoryService(
            ICategoryRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<CategoryService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }

        /// <inheritdoc/>
        public IList<ITreeNode<long, Category>> GetCategoryTreeByType(int typeId, bool includeDisable)
        {
            var query = new CategoryQueryParameter();
            query.CategoryTypeId = typeId;
            query.ParentId = 0;

            if (includeDisable)
            {
                query.IsEnabled = null;
            }
            else
            {
                query.IsEnabled = true;
            }

            var roots = Get(query);

            var nodes = new List<ITreeNode<long, Category>>();

            foreach (var item in roots)
            {
                nodes.Add(this.GetTree(item.Id));
            }

            return nodes;
        }

        /// <inheritdoc/>
        public async Task<IList<ITreeNode<long, Category>>> GetCategoryTreeByTypeAsync(int typeId, bool includeDisable)
        {
            var query = new CategoryQueryParameter();
            query.CategoryTypeId = typeId;
            query.ParentId = 0;

            if (includeDisable)
            {
                query.IsEnabled = null;
            }
            else
            {
                query.IsEnabled = true;
            }

            var roots = await GetAsync(query);

            var nodes = new List<ITreeNode<long, Category>>();

            foreach (var item in roots)
            {
                nodes.Add(await this.GetTreeAsync(item.Id));
            }

            return nodes;
        }
    }
}
