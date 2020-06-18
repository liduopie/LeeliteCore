using Leelite.Framework.WebApi;
using Leelite.Modules.Identity.Dtos.RoleClaimDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.RoleClaimAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Identity.WebApi
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