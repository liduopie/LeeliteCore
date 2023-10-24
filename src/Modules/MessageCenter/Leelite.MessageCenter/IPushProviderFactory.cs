using Leelite.MessageCenter.Models.PushPlatformAgg;

namespace Leelite.MessageCenter
{
    public interface IPushProviderFactory
    {
        public IPushProvider Create(PushPlatform platform);
    }
}
