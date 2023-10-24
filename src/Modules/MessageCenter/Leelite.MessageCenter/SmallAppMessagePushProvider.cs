using System.Collections.Generic;

using Leelite.MessageCenter.Models.PushRecordAgg;

namespace Leelite.MessageCenter
{
    public class SmallAppMessagePushProvider : PushProviderBase
    {
        public SmallAppMessagePushProvider()
        {
            ProviderName = "SmallAppMessage";
        }

        public override bool Push(PushRecord record)
        {
            return true;
        }

        public override void SetConfig(IDictionary<string, string> config)
        {
        }
    }
}
