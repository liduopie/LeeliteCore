using System.Collections.Generic;

using Leelite.Framework.WebApi;
using Leelite.MessageCenter.Dtos.MessageDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.MessageAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.MessageCenter.WebApi
{
    [ApiController]
    [Area("MessageCenter")]
    [Route("api/[area]/[controller]")]
    public class MessageController : RESTfulController<Message, long, MessageDto, MessageCreateRequest, MessageUpdateRequest, MessageQueryParameter>
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetUserUnReadCount")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public IList<MessageUserReadCount> GetUserUnReadCount(long userId)
        {
            return _service.GetUserUnReadCount(userId);
        }
    }
}