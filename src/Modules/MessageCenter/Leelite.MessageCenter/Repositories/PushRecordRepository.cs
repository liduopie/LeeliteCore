using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.MessageCenter.Contexts;
using Leelite.MessageCenter.Models.PushRecordAgg;

namespace Leelite.MessageCenter.Repositories
{
    public interface IPushRecordRepository : IRepository<PushRecord, long>
    {
    }

    public class PushRecordRepository : EFRepository<PushRecord, long>, IPushRecordRepository
    {
        public PushRecordRepository(MessageContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
