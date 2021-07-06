using Leelite.Framework.Service;
using Leelite.Modules.Message.Models.MessageAgg.Dtos.MessageDtos;
using Leelite.Modules.Message.Models.MessageAgg.Models.MessageAgg;

namespace Leelite.Modules.Message.Models.MessageAgg.Interfaces
{
    public interface IMessageService : ICrudService<Message, long, MessageDto, MessageCreateRequest, MessageUpdateRequest, MessageQueryParameter>
    {
    }
}
