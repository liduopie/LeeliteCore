using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.RoleClaimDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.RoleClaimAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.Api.Controllers.Admin
{
    [Area("Identity")]
    public class RoleClaimController : RESTfulController<RoleClaim, int, RoleClaimDto, RoleClaimCreateRequest, RoleClaimUpdateRequest, RoleClaimQueryParameter>
    {
        private readonly IRoleClaimService _service;

        public RoleClaimController(IRoleClaimService service) : base(service)
        {
            _service = service;
        }
    }
}