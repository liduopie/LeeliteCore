using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.MessageCenter.Contexts;
using Leelite.MessageCenter.Models.MessageAgg;

namespace Leelite.MessageCenter.Repositories
{
    public interface IMessageRepository : IRepository<Message, long>
    {
    }

    public class MessageRepository : EFRepository<Message, long>, IMessageRepository
    {
        public MessageRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
