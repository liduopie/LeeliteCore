using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Dtos.PushRecordDtos;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg.Models.PushRecordAgg;

namespace Leelite.Modules.MessageCenter.Models.PushRecordAgg.Interfaces
{
    public interface IPushRecordService : ICrudService<PushRecord, long, PushRecordDto, PushRecordCreateRequest, PushRecordUpdateRequest, PushRecordQueryParameter>
    {
    }
}
