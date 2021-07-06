using Leelite.Framework.WebApi;
using Leelite.Modules.Message.Models.SessionAgg.Dtos.SessionDtos;
using Leelite.Modules.Message.Models.SessionAgg.Interfaces;
using Leelite.Modules.Message.Models.SessionAgg.Models.SessionAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Message.Models.SessionAgg.WebApi
{
    [ApiController]
    [Area("SessionAgg")]
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