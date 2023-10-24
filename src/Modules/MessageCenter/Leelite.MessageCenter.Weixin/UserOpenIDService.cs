using ZiggyCreatures.Caching.Fusion;

namespace Leelite.MessageCenter.Weixin
{
    public class UserOpenIDService : IUserOpenIDService
    {
        private readonly IUserOpenIDFactory _userOpenIDFactory;
        private readonly IFusionCache _cache;

        public UserOpenIDService(IUserOpenIDFactory factory, IFusionCache cache)
        {
            _userOpenIDFactory = factory;
            _cache = cache;
        }

        public string GetOpenID(string appId, long userId)
        {
            var cacheKey = $"MessageCenter:UserOpenID:{appId}:{userId}";

            var result = _cache.GetOrSet(
                    cacheKey,
                    _ => _userOpenIDFactory.GetOpenId(appId, userId));

            return result;
        }
    }
}
