using Leelite.Framework.Service;
using Leelite.Modules.Message.Models.MessageTypeAgg.Dtos.MessageTypeDtos;
using Leelite.Modules.Message.Models.MessageTypeAgg.Models.MessageTypeAgg;

namespace Leelite.Modules.Message.Models.MessageTypeAgg.Interfaces
{
    public interface IMessageTypeService : ICrudService<MessageType, int, MessageTypeDto, MessageTypeCreateRequest, MessageTypeUpdateRequest, MessageTypeQueryParameter>
    {
    }
}
