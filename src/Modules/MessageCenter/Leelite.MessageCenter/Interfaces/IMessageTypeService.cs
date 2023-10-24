using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.MessageTypeDtos;
using Leelite.MessageCenter.Models.MessageTypeAgg;

namespace Leelite.MessageCenter.Interfaces
{
    public interface IMessageTypeService : ICrudService<MessageType, int, MessageTypeDto, MessageTypeCreateRequest, MessageTypeUpdateRequest, MessageTypeQueryParameter>
    {
    }
}
