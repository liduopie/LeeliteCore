using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Dtos.PushRecordDtos;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Interfaces;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Models.PushRecordAgg;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Repositories;
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
