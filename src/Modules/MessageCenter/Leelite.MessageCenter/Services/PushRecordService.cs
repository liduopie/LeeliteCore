using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.PushRecordDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.PushRecordAgg;
using Leelite.MessageCenter.Repositories;

using Microsoft.Extensions.Logging;

namespace Leelite.MessageCenter.Services
{
    public class PushRecordService : CrudService<PushRecord, long, PushRecordDto, PushRecordCreateRequest, PushRecordUpdateRequest, PushRecordQueryParameter>, IPushRecordService
    {
        public PushRecordService(
            IPushRecordRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<PushRecordService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
        }
    }
}
