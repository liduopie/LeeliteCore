using Leelite.Framework.WebApi;
using Leelite.Identity.Dtos.UserFingerprintDtos;
using Leelite.Identity.Interfaces;
using Leelite.Identity.Models.UserFingerprintAgg;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.Identity.Api.Controllers.Admin
{
    [Area("Identity")]
    public class UserFingerprintController : RESTfulController<UserFingerprint, long, UserFingerprintDto, UserFingerprintCreateRequest, UserFingerprintUpdateRequest, UserFingerprintQueryParameter>
    {
        private readonly IUserFingerprintService _service;

        public UserFingerprintController(IUserFingerprintService service) : base(service)
        {
            _service = service;
        }
    }
}