using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Message.Dtos.MessageTypeDtos;
using Leelite.Modules.Message.Interfaces;
using Leelite.Modules.Message.Models.MessageTypeAgg;
using Leelite.Modules.Message.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Message.Models.MessageTypeAgg.Services
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
