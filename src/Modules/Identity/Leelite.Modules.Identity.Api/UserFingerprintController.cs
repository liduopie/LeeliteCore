using Leelite.Framework.WebApi;
using Leelite.Modules.Identity.Dtos.UserFingerprintDtos;
using Leelite.Modules.Identity.Interfaces;
using Leelite.Modules.Identity.Models.UserFingerprintAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.Modules.Identity.WebApi
{
    [ApiController]
    [Area("Identity")]
    [Route("api/[area]/[controller]")]
    public class UserFingerprintController : RESTfulController<UserFingerprint, long, UserFingerprintDto, UserFingerprintCreateRequest, UserFingerprintUpdateRequest, UserFingerprintQueryParameter>
    {
        private readonly IUserFingerprintService _service;

        public UserFingerprintController(IUserFingerprintService service) : base(service)
        {
            _service = service;
        }
    }
}