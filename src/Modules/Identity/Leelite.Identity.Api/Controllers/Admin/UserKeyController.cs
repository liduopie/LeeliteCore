using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.UserKeyDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserKeyAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.Api.Controllers.Admin
{
    [Area("Identity")]
    public class UserKeyController : RESTfulController<UserKey, long, UserKeyDto, UserKeyCreateRequest, UserKeyUpdateRequest, UserKeyQueryParameter>
    {
        private readonly IUserKeyService _service;

        public UserKeyController(IUserKeyService service) : base(service)
        {
            _service = service;
        }
    }
}