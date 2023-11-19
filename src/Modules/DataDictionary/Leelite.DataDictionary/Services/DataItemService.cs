using Leelite.DataDictionary.Dtos.DataItemDtos;
using Leelite.DataDictionary.Interfaces;
using Leelite.DataDictionary.Models.DataItemAgg;
using Leelite.DataDictionary.Repositories;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;

using Microsoft.Extensions.Logging;

namespace Leelite.DataDictionary.Services
{
    public class DataItemService : CrudService<DataItem, int, DataItemDto, DataItemCreateRequest, DataItemUpdateRequest, DataItemQueryParameter>, IDataItemService
    {
        public DataItemService(
            IDataItemRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<DataItemService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }
    }
}
