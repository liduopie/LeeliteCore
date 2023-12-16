using AspNetCore.Authentication.ApiKey;

using Leelite.ApiAuth.Repositories;

using Microsoft.Extensions.Logging;

namespace Leelite.ApiAuth.Services
{
    public class ApiKeyProvider : IApiKeyProvider
    {
        private readonly ILogger<IApiKeyProvider> _logger;
        private readonly IApiKeyRepository _apiKeyRepository;

        public ApiKeyProvider(ILogger<IApiKeyProvider> logger, IApiKeyRepository apiKeyRepository)
        {
            _logger = logger;
            _apiKeyRepository = apiKeyRepository;
        }

        public async Task<IApiKey> ProvideAsync(string key)
        {
            try
            {
                return await _apiKeyRepository.GetApiKeyAsync(key);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}
