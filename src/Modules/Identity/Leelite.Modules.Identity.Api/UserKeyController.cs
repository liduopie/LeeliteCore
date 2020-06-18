using Leelite.Framework.WebApi;
using Leelite.Modules.Identity.Dtos.UserKeyDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserKeyAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Identity.WebApi
{
    [ApiController]
    [Area("Identity")]
    [Route("api/[area]/[controller]")]
    public class UserKeyController : RESTfulController<UserKey, long, UserKeyDto, UserKeyCreateRequest, UserKeyUpdateRequest, UserKeyQueryParameter>
    {
        private readonly IUserKeyService _service;

        public UserKeyController(IUserKeyService service) : base(service)
        {
            _service = service;
        }
    }
}