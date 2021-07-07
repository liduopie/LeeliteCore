using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.MessageCenter.Contexts;
using Leelite.Modules.MessageCenter.Models.TemplateAgg;

namespace Leelite.Modules.MessageCenter.Repositories
{
    public interface ITemplateRepository : IRepository<Template, long>
    {
    }

    public class TemplateRepository : EFRepository<Template, long>, ITemplateRepository
    {
        public TemplateRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
