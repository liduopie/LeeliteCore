using Leelite.Framework.WebApi;
using Leelite.Modules.MessageCenter.Dtos.SessionDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.SessionAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.MessageCenter.Models.SessionAgg.WebApi
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