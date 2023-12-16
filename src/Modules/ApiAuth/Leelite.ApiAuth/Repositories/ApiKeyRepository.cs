using Leelite.ApiAuth.Contexts;
using Leelite.ApiAuth.Models.ApiKeyAgg;
using Leelite.Framework.Domain.Repository;
using Leelite.Framework.Domain.UnitOfWork;

using Microsoft.EntityFrameworkCore;

namespace Leelite.ApiAuth.Repositories
{
    public interface IApiKeyRepository : IRepository<ApiKey, long>
    {
        Task<ApiKey> GetApiKeyAsync(string key);
    }

    public class ApiKeyRepository : EFRepository<ApiKey, long>, IApiKeyRepository
    {
        public ApiKeyRepository(ApiAuthContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork) { }

        public async Task<ApiKey> GetApiKeyAsync(string key)
        {
            return await AsQueryable().Where(c => c.Key == key).FirstOrDefaultAsync();
        }
    }
}
