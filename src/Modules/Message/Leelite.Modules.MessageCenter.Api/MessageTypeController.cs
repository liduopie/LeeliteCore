using Leelite.Framework.WebApi;
using Leelite.Modules.MessageCenter.Dtos.MessageTypeDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.MessageCenter.Models.MessageTypeAgg.WebApi
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