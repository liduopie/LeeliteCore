using Leelite.DataDictionary.Dtos.DataTypeDtos;
using Leelite.DataDictionary.Interfaces;
using Leelite.DataDictionary.Models.DataTypeAgg;
using Leelite.DataDictionary.Repositories;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;

using Microsoft.Extensions.Logging;

namespace Leelite.DataDictionary.Services
{
    public class DataTypeService : CrudService<DataType, string, DataTypeDto, DataTypeCreateRequest, DataTypeUpdateRequest, DataTypeQueryParameter>, IDataTypeService
    {
        public DataTypeService(
            IDataTypeRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<DataTypeService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }
    }
}
