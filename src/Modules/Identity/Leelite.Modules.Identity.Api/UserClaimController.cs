using Leelite.Framework.WebApi;
using Leelite.Modules.Identity.Dtos.UserClaimDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserClaimAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Identity.WebApi
{
    [ApiController]
    [Area("Identity")]
    [Route("api/[area]/[controller]")]
    public class UserClaimController : RESTfulController<UserClaim, long, UserClaimDto, UserClaimCreateRequest, UserClaimUpdateRequest, UserClaimQueryParameter>
    {
        private readonly IUserClaimService _service;

        public UserClaimController(IUserClaimService service) : base(service)
        {
            _service = service;
        }
    }
}