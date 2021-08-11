using Leelite.Core.Cache;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.MessageDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Repositories;

using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

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

        [Cache(nameof(Message))]
        public override Task<MessageDto> GetByIdAsync(long id)
        {
            return base.GetByIdAsync(id);
        }
    }
}
