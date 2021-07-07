using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Modules.Message.Contexts;
using Leelite.Modules.Message.Models.MessageAgg;

namespace Leelite.Modules.Message.Repositories
{
    public interface IMessageRepository : IRepository<Models.MessageAgg.Message, long>
    {
    }

    public class MessageRepository : EFRepository<Models.MessageAgg.Message, long>, IMessageRepository
    {
        public MessageRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
