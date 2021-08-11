using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.PushRecordDtos;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg;

namespace Leelite.Modules.MessageCenter.Interfaces
{
    public interface IPushRecordService : ICrudService<PushRecord, long, PushRecordDto, PushRecordCreateRequest, PushRecordUpdateRequest, PushRecordQueryParameter>
    {
    }
}
