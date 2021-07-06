using Leelite.Framework.WebApi;
using Leelite.Modules.Message.Models.MessageTypeAgg.Dtos.MessageTypeDtos;
using Leelite.Modules.Message.Models.MessageTypeAgg.Interfaces;
using Leelite.Modules.Message.Models.MessageTypeAgg.Models.MessageTypeAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Message.Models.MessageTypeAgg.WebApi
{
    [ApiController]
    [Area("MessageTypeAgg")]
    [Route("api/[area]/[controller]")]
    public class MessageTypeController : RESTfulController<MessageType, int, MessageTypeDto, MessageTypeCreateRequest, MessageTypeUpdateRequest, MessageTypeQueryParameter>
    {
        private readonly IMessageTypeService _service;

        public MessageTypeController(IMessageTypeService service) : base(service)
        {
            _service = service;
        }
    }
}