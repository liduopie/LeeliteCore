using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Message.Contexts;
using Leelite.Modules.Message.Models.SessionAgg;

namespace Leelite.Modules.Message.Repositories
{
    public interface ISessionRepository : IRepository<Session, long>
    {
    }

    public class SessionRepository : EFRepository<Session, long>, ISessionRepository
    {
        public SessionRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
