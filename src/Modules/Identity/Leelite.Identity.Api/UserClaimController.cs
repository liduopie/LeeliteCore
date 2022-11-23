using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.UserClaimDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserClaimAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.WebApi
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