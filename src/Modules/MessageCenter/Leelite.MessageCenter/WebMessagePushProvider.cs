using System.Collections.Generic;

using Leelite.MessageCenter.Models.PushRecordAgg;

namespace Leelite.MessageCenter
{
    public class WebMessagePushProvider : PushProviderBase
    {
        public WebMessagePushProvider()
        {
            ProviderName = "WebMessage";
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
