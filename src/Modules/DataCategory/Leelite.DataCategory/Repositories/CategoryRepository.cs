using Leelite.DataCategory.Contexts;
using Leelite.DataCategory.Models.CategoryAgg;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;

namespace Leelite.DataCategory.Repositories
{
    public interface ICategoryRepository : IRepository<Category, long>
    {
    }

    public class CategoryRepository : EFRepository<Category, long>, ICategoryRepository
    {
        public CategoryRepository(DataCategoryContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
