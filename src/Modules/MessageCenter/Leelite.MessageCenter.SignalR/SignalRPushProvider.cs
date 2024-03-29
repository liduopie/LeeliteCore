﻿using System.Collections.Generic;

using Leelite.MessageCenter.Models.PushRecordAgg;

using Microsoft.AspNetCore.SignalR;

namespace Leelite.MessageCenter.SignalR
{

    public class SignalRPushProvider : PushProviderBase
    {
        private readonly IHubContext<MessageCenterHub> _hubContext;

        public SignalRPushProvider(IHubContext<MessageCenterHub> hubContext)
        {
            _hubContext = hubContext;
            ProviderName = "SignalR";
        }

        public override bool Push(PushRecord record)
        {
            var result = _hubContext.Clients.User(record.UserId.ToString()).SendAsync(record.TemplateCode, record.Content);

            return true;
        }

        public override void SetConfig(IDictionary<string, string> config)
        {

        }
    }
}
