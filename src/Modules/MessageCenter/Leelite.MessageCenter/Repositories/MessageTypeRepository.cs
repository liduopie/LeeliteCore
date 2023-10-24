using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.MessageCenter.Contexts;
using Leelite.MessageCenter.Models.MessageTypeAgg;

namespace Leelite.MessageCenter.Repositories
{
    public interface IMessageTypeRepository : IRepository<MessageType, int>
    {
    }

    public class MessageTypeRepository : EFRepository<MessageType, int>, IMessageTypeRepository
    {
        public MessageTypeRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
