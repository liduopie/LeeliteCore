using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.MessageCenter.Contexts;
using Leelite.Modules.MessageCenter.Models.SessionAgg;

namespace Leelite.Modules.MessageCenter.Repositories
{
    public interface ISessionRepository : IRepository<Session, long>
    {
    }

    public class SessionRepository : EFRepository<Session, long>, ISessionRepository
    {
        public SessionRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
