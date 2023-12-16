using Leelite.Framework.Service;
using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Models.ApiKeyAgg;

namespace Leelite.ApiAuth.Interfaces
{
    public interface IApiKeyService : ICrudService<ApiKey, long, ApiKeyDto, ApiKeyCreateRequest, ApiKeyUpdateRequest, ApiKeyQueryParameter>
    {
        Task<ApiKey> GetApiKeyAsync(string key);
    }
}
