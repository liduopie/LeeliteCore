using Leelite.Modules.MessageCenter.Models.PlatformAgg;

using System;
using System.Collections.Generic;
using System.Text;

namespace Leelite.Modules.MessageCenter
{
    public interface IPushProviderFactory
    {
        public IPushProvider Create(PushPlatform platform);
    }
}
