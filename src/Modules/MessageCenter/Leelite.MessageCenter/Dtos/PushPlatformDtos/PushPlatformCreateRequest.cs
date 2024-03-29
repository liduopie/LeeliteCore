using Leelite.Framework.Service.Dtos;

using System.Collections.Generic;

namespace Leelite.MessageCenter.Dtos.PushPlatformDtos
{
    public class PushPlatformCreateRequest : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProviderName { get; set; }

        public IDictionary<string, string> Config { get; set; }

        public int Priority { get; set; }

        public bool IsEnabled { get; set; }

    }
}
