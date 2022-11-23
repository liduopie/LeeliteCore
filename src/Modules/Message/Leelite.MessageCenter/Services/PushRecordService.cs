using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.PushRecordDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg;
using Leelite.Modules.MessageCenter.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.MessageCenter.Models.PushRecordAgg.Services
{
    public class PushRecordService : CrudService<PushRecord, long, PushRecordDto, PushRecordCreateRequest, PushRecordUpdateRequest, PushRecordQueryParameter>, IPushRecordService
    {
        public PushRecordService(
            IPushRecordRepository repository,
            ICommandBus commandBus,
            ILogger<PushRecordService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
