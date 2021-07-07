using Leelite.Framework.Service;
using Leelite.Modules.Message.Dtos.MessageTypeDtos;
using Leelite.Modules.Message.Models.MessageTypeAgg;

namespace Leelite.Modules.Message.Interfaces
{
    public interface IMessageTypeService : ICrudService<MessageType, int, MessageTypeDto, MessageTypeCreateRequest, MessageTypeUpdateRequest, MessageTypeQueryParameter>
    {
    }
}
