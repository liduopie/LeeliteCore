using Leelite.DataDictionary.Contexts;
using Leelite.DataDictionary.Models.DataItemAgg;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;

namespace Leelite.DataDictionary.Repositories
{
    public interface IDataItemRepository : IRepository<DataItem, int>
    {
    }

    public class DataItemRepository : EFRepository<DataItem, int>, IDataItemRepository
    {
        public DataItemRepository(DataDictionaryContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
