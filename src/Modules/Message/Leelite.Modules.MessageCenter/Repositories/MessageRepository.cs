using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.MessageCenter.Contexts;
using Leelite.Modules.MessageCenter.Models.MessageAgg;

namespace Leelite.Modules.MessageCenter.Repositories
{
    public interface IMessageRepository : IRepository<Message, long>
    {
    }

    public class MessageRepository : EFRepository<Message, long>, IMessageRepository
    {
        public MessageRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
