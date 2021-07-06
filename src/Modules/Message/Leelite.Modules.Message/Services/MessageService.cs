using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.Message.Models.MessageAgg.Dtos.MessageDtos;
using Leelite.Modules.Message.Models.MessageAgg.Interfaces;
using Leelite.Modules.Message.Models.MessageAgg.Models.MessageAgg;
using Leelite.Modules.Message.Models.MessageAgg.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.Message.Models.MessageAgg.Services
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
