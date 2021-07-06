using Leelite.Framework.WebApi;
using Leelite.Modules.Message.Models.MessageAgg.Dtos.MessageDtos;
using Leelite.Modules.Message.Models.MessageAgg.Interfaces;
using Leelite.Modules.Message.Models.MessageAgg.Models.MessageAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Message.Models.MessageAgg.WebApi
{
    [ApiController]
    [Area("MessageAgg")]
    [Route("api/[area]/[controller]")]
    public class MessageController : RESTfulController<Message, long, MessageDto, MessageCreateRequest, MessageUpdateRequest, MessageQueryParameter>
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service) : base(service)
        {
            _service = service;
        }
    }
}