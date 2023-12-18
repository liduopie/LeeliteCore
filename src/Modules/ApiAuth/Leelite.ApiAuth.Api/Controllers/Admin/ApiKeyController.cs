using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Interfaces;
using Leelite.ApiAuth.Models.ApiKeyAgg;
using Leelite.Framework.WebApi;

using Microsoft.AspNetCore.Mvc;

namespace Leelite.ApiAuth.Api.Controllers.Admin
{
    [Area("ApiAuth")]
    public class ApiKeyController : RESTfulController<ApiKey, long, ApiKeyDto, ApiKeyCreateRequest, ApiKeyUpdateRequest, ApiKeyQueryParameter>
    {
        private readonly IApiKeyService _service;

        public ApiKeyController(IApiKeyService service) : base(service)
        {
            _service = service;
        }
    }
}