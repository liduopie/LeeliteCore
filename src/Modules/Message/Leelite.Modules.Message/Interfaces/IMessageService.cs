using Leelite.Framework.Service;
using Leelite.Modules.Message.Dtos.MessageDtos;
using Leelite.Modules.Message.Models.MessageAgg;

namespace Leelite.Modules.Message.Interfaces
{
    public interface IMessageService : ICrudService<Models.MessageAgg.Message, long, MessageDto, MessageCreateRequest, MessageUpdateRequest, MessageQueryParameter>
    {
    }
}
