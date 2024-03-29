using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.UserClaimDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserClaimAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.Api.Controllers.Admin
{
    [Area("Identity")]
    public class UserClaimController : RESTfulController<UserClaim, long, UserClaimDto, UserClaimCreateRequest, UserClaimUpdateRequest, UserClaimQueryParameter>
    {
        private readonly IUserClaimService _service;

        public UserClaimController(IUserClaimService service) : base(service)
        {
            _service = service;
        }
    }
}