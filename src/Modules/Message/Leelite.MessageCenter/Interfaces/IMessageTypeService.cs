using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.MessageTypeDtos;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;

namespace Leelite.Modules.MessageCenter.Interfaces
{
    public interface IMessageTypeService : ICrudService<MessageType, int, MessageTypeDto, MessageTypeCreateRequest, MessageTypeUpdateRequest, MessageTypeQueryParameter>
    {
    }
}
