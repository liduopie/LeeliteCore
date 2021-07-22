using ZiggyCreatures.Caching.Fusion;

namespace Leelite.Modules.MessageCenter.SMS
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

        public string GetPhone(long id)
        {
            var cacheKey = $"MessageCenter:UserPhone:{id}";

            var result = _cache.GetOrSet(
                    cacheKey,
                    _ => _userPhoneFactory.GetPhone(id));

            return result;
        }
    }
}
