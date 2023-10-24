using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Leelite.Core.Cache;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.MessageDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.MessageAgg;
using Leelite.MessageCenter.Repositories;

using Microsoft.Extensions.Logging;

namespace Leelite.MessageCenter.Services
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

        //[UnitOfWork]
        public void Delivered(long id)
        {
            var msg = Repository.FindById(id);

            if (msg == null) return;

            if (msg.DeliveryState) return;

            msg.DeliveryState = true;

            Repository.Update(msg);
        }

        //[UnitOfWork]
        public void GenerateRecord(long id)
        {
            var msg = Repository.FindById(id);

            if (msg == null) return;

            if (msg.GenerateRecord) return;

            msg.GenerateRecord = true;

            Repository.Update(msg);
        }


        [Cache(nameof(Message))]
        public override Task<MessageDto> GetByIdAsync(long id)
        {
            return base.GetByIdAsync(id);
        }

        public IList<MessageUserReadCount> GetUserUnReadCount(long userId)
        {
            if (userId <= 0)
            {
                return null;
            }
            var UserRead = from c in Repository.AsQueryable()
                           where c.UserId == userId && c.ReadState == false
                           group c by c.MessageTypeId into g
                           select new MessageUserReadCount { TypeId = g.Key, Total = g.Count() };

            return null;
        }
    }
}
