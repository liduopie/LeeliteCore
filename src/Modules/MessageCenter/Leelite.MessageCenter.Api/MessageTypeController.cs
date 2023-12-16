using Leelite.Framework.WebApi;
using Leelite.MessageCenter.Dtos.MessageTypeDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.MessageTypeAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.MessageCenter.Api
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "manager")]
    [Area("MessageCenter")]
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