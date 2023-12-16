using Leelite.ApiAuth.Dtos.ApiKeyDtos;
using Leelite.ApiAuth.Interfaces;
using Leelite.ApiAuth.Models.ApiKeyAgg;
using Leelite.ApiAuth.Repositories;
using Leelite.Framework.Domain.Command;
using Leelite.Framework.Domain.UnitOfWork;
using Leelite.Framework.Service;

using Microsoft.Extensions.Logging;

namespace Leelite.ApiAuth.Services
{
    public class ApiKeyService : CrudService<ApiKey, long, ApiKeyDto, ApiKeyCreateRequest, ApiKeyUpdateRequest, ApiKeyQueryParameter>, IApiKeyService
    {
        private readonly IApiKeyRepository _apiKeyRepository;

        public ApiKeyService(
            IApiKeyRepository repository,
            ICommandBus commandBus,
            IUnitOfWork unitOfWork,
            ILogger<ApiKeyService> logger
            ) : base(repository, commandBus, unitOfWork, logger)
        {
            _apiKeyRepository = repository;
        }

        public async Task<ApiKey> GetApiKeyAsync(string key)
        {
            return await _apiKeyRepository.GetApiKeyAsync(key);
        }
    }
}
