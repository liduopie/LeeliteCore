using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Contexts;
using Leelite.Modules.MessageCenter.Models.TemplateAgg.Models.TemplateAgg;

namespace Leelite.Modules.MessageCenter.Models.TemplateAgg.Repositories
{
    public interface ITemplateRepository : IRepository<Template, long>
    {
    }

    public class TemplateRepository : EFRepository<Template, long>, ITemplateRepository
    {
        public TemplateRepository(TemplateAggContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
