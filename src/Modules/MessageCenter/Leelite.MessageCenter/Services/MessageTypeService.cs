using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.MessageTypeDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.MessageTypeAgg;
using Leelite.MessageCenter.Repositories;

using Microsoft.Extensions.Logging;

namespace Leelite.MessageCenter.Services
{
    public class MessageTypeService : CrudService<MessageType, int, MessageTypeDto, MessageTypeCreateRequest, MessageTypeUpdateRequest, MessageTypeQueryParameter>, IMessageTypeService
    {
        public MessageTypeService(
            IMessageTypeRepository repository,
            ICommandBus commandBus,
            ILogger<MessageTypeService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
