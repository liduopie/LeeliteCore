using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.PushRecordDtos;
using Leelite.MessageCenter.Models.PushRecordAgg;

namespace Leelite.MessageCenter.Interfaces
{
    public interface IPushRecordService : ICrudService<PushRecord, long, PushRecordDto, PushRecordCreateRequest, PushRecordUpdateRequest, PushRecordQueryParameter>
    {
    }
}
