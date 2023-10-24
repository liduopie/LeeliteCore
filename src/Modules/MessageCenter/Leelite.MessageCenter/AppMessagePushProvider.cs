using Leelite.MessageCenter.Models.PushRecordAgg;

using System.Collections.Generic;

namespace Leelite.MessageCenter
{
    public class AppMessagePushProvider : PushProviderBase
    {
        public AppMessagePushProvider()
        {
            ProviderName = "AppMessage";
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
