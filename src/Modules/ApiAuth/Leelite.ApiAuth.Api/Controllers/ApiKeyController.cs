using Leelite.Framework.WebApi;
using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Interfaces;
using Leelite.ApiAuth.Models.ApiKeyAgg;
using Microsoft.AspNetCore.Mvc;

namespace Leelite.ApiAuth.Api.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "manager")]
    [Area("ApiAuth")]
    [Route("api/[area]/[controller]")]
    public class ApiKeyController : RESTfulController<ApiKey, long, ApiKeyDto, ApiKeyCreateRequest, ApiKeyUpdateRequest, ApiKeyQueryParameter>
    {
        private readonly IApiKeyService _service;

        public ApiKeyController(IApiKeyService service) : base(service)
        {
            _service = service;
        }
    }
}