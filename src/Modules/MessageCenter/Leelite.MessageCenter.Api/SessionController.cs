using Leelite.Framework.WebApi;
using Leelite.MessageCenter.Dtos.SessionDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.SessionAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.MessageCenter.Api
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "manager")]
    [Area("MessageCenter")]
    [Route("api/[area]/[controller]")]
    public class SessionController : RESTfulController<Session, long, SessionDto, SessionCreateRequest, SessionUpdateRequest, SessionQueryParameter>
    {
        private readonly ISessionService _service;

        public SessionController(ISessionService service) : base(service)
        {
            _service = service;
        }
    }
}