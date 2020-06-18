using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Samples.ModuleSample.Contexts;
using Leelite.Samples.ModuleSample.Models.BlogAgg;

namespace Leelite.Samples.ModuleSample.Repositories
{
    public interface IBlogRepository : IRepository<Blog, int>
    {
    }

    public class BlogRepository : EFRepository<Blog, int>, IBlogRepository
    {
        public BlogRepository(BloggingContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
