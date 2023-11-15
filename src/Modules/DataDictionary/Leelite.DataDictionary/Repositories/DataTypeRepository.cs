using Leelite.DataDictionary.Contexts;
using Leelite.DataDictionary.Models.DataTypeAgg;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;

namespace Leelite.DataDictionary.Repositories
{
    public interface IDataTypeRepository : IRepository<DataType, string>
    {
    }

    public class DataTypeRepository : EFRepository<DataType, string>, IDataTypeRepository
    {
        public DataTypeRepository(DataDictionaryContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }
    }
}
