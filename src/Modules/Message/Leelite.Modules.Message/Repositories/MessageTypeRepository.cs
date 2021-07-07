using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Message.Contexts;
using Leelite.Modules.Message.Models.MessageTypeAgg;

namespace Leelite.Modules.Message.Repositories
{
    public interface IMessageTypeRepository : IRepository<MessageType, int>
    {
    }

    public class MessageTypeRepository : EFRepository<MessageType, int>, IMessageTypeRepository
    {
        public MessageTypeRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
