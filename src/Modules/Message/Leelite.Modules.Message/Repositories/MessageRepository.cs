using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Message.Models.MessageAgg.Contexts;
using Leelite.Modules.Message.Models.MessageAgg.Models.MessageAgg;

namespace Leelite.Modules.Message.Models.MessageAgg.Repositories
{
    public interface IMessageRepository : IRepository<Message, long>
    {
    }

    public class MessageRepository : EFRepository<Message, long>, IMessageRepository
    {
        public MessageRepository(MessageAggContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
