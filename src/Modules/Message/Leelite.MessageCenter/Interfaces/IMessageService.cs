using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.MessageDtos;
using Leelite.Modules.MessageCenter.Models.MessageAgg;

namespace Leelite.Modules.MessageCenter.Interfaces
{
    public interface IMessageService : ICrudService<Message, long, MessageDto, MessageCreateRequest, MessageUpdateRequest, MessageQueryParameter>
    {
    }
}
