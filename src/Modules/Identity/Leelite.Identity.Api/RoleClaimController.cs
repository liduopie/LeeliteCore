using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.RoleClaimDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.RoleClaimAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.Api
{
    [ApiController]
    [Area("Identity")]
    [Route("api/[area]/[controller]")]
    public class RoleClaimController : RESTfulController<RoleClaim, int, RoleClaimDto, RoleClaimCreateRequest, RoleClaimUpdateRequest, RoleClaimQueryParameter>
    {
        private readonly IRoleClaimService _service;

        public RoleClaimController(IRoleClaimService service) : base(service)
        {
            _service = service;
        }
    }
}