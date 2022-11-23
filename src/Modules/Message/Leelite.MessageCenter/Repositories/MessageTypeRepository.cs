using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.MessageCenter.Contexts;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;

namespace Leelite.Modules.MessageCenter.Repositories
{
    public interface IMessageTypeRepository : IRepository<MessageType, int>
    {
    }

    public class MessageTypeRepository : EFRepository<MessageType, int>, IMessageTypeRepository
    {
        public MessageTypeRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
