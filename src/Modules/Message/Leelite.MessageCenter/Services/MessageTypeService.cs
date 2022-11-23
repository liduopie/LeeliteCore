using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.MessageTypeDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;
using Leelite.Modules.MessageCenter.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.MessageCenter.Models.MessageTypeAgg.Services
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
