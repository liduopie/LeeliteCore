using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Message.Models.MessageTypeAgg.Contexts;
using Leelite.Modules.Message.Models.MessageTypeAgg.Models.MessageTypeAgg;

namespace Leelite.Modules.Message.Models.MessageTypeAgg.Repositories
{
    public interface IMessageTypeRepository : IRepository<MessageType, int>
    {
    }

    public class MessageTypeRepository : EFRepository<MessageType, int>, IMessageTypeRepository
    {
        public MessageTypeRepository(MessageTypeAggContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
