using Leelite.Framework.WebApi;
using Leelite.Modules.MessageCenter.Dtos.MessageDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.MessageAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.MessageCenter.Models.MessageAgg.WebApi
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