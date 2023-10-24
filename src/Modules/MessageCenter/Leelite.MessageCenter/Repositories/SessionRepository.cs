using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.MessageCenter.Contexts;
using Leelite.MessageCenter.Models.SessionAgg;

namespace Leelite.MessageCenter.Repositories
{
    public interface ISessionRepository : IRepository<Session, long>
    {
    }

    public class SessionRepository : EFRepository<Session, long>, ISessionRepository
    {
        public SessionRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
