using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.MessageCenter.Contexts;
using Leelite.MessageCenter.Models.TemplateAgg;

namespace Leelite.MessageCenter.Repositories
{
    public interface ITemplateRepository : IRepository<Template, int>
    {
    }

    public class TemplateRepository : EFRepository<Template, int>, ITemplateRepository
    {
        public TemplateRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
