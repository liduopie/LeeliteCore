using ZiggyCreatures.Caching.Fusion;

namespace Leelite.MessageCenter.SMS
{
    public class UserPhoneService : IUserPhoneService
    {
        private readonly IUserPhoneFactory _userPhoneFactory;
        private readonly IFusionCache _cache;

        public UserPhoneService(IUserPhoneFactory factory, IFusionCache cache)
        {
            _userPhoneFactory = factory;
            _cache = cache;
        }

        public string GetPhone(long userId)
        {
            var cacheKey = $"MessageCenter:UserPhone:{userId}";

            var result = _cache.GetOrSet(
                    cacheKey,
                    _ => _userPhoneFactory.GetPhone(userId));

            return result;
        }
    }
}
