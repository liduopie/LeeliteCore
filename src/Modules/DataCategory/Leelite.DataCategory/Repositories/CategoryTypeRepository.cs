using Leelite.DataCategory.Contexts;
using Leelite.DataCategory.Models.CategoryTypeAgg;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;

namespace Leelite.DataCategory.Repositories
{
    public interface ICategoryTypeRepository : IRepository<CategoryType, int>
    {
    }

    public class CategoryTypeRepository : EFRepository<CategoryType, int>, ICategoryTypeRepository
    {
        public CategoryTypeRepository(DataCategoryContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
