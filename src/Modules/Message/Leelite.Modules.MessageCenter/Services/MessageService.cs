using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.MessageDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.MessageAgg;
using Leelite.Modules.MessageCenter.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.MessageCenter.Models.MessageAgg.Services
{
    public class MessageService : CrudService<Message, long, MessageDto, MessageCreateRequest, MessageUpdateRequest, MessageQueryParameter>, IMessageService
    {
        public MessageService(
            IMessageRepository repository,
            ICommandBus commandBus,
            ILogger<MessageService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
