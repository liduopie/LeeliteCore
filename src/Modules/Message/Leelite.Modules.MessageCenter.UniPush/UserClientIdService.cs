
using ZiggyCreatures.Caching.Fusion;

namespace Leelite.Modules.MessageCenter.UniPush
{
    public class UserClientIdService : IUserClientIdService
    {
        private readonly IUserClientIdFactory _userClientIdFactory;
        private readonly IFusionCache _cache;

        public UserClientIdService(IUserClientIdFactory factory, IFusionCache cache)
        {
            _userClientIdFactory = factory;
            _cache = cache;
        }

        public string GetClientID(long userId)
        {
            var cacheKey = $"MessageCenter:UserClientId:{userId}";

            var result = _cache.GetOrSet(
                    cacheKey,
                    _ => _userClientIdFactory.GetClientId(userId));

            return result;
        }
    }
}
