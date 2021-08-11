﻿using Leelite.Modules.MessageCenter.Models.PlatformAgg;

using Microsoft.Extensions.DependencyInjection;

using System;

namespace Leelite.Modules.MessageCenter
{
    public class PushProviderFactory : IPushProviderFactory
    {
        private readonly IServiceProvider _serviceProvider;


        public PushProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPushProvider Create(PushPlatform platform)
        {
            var providers = _serviceProvider.GetServices<IPushProvider>();

            IPushProvider pushProvider = null;
            foreach (var item in providers)
            {
                if (platform.ProviderName == item.ProviderName)
                {
                    pushProvider = item;
                    break;
                }
            }

            if (pushProvider != null)
            {
                pushProvider.SetConfig(platform.Config);
            }

            return pushProvider;
        }
    }
}
