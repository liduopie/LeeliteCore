using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.MessageDtos;
using Leelite.Modules.MessageCenter.Models.MessageAgg;

namespace Leelite.Modules.MessageCenter.Interfaces
{
    public interface IMessageService : ICrudService<Models.MessageAgg.Message, long, MessageDto, MessageCreateRequest, MessageUpdateRequest, MessageQueryParameter>
    {
    }
}
