using Leelite.Framework.Service.Dtos;

using System.Collections.Generic;

namespace Leelite.Modules.MessageCenter.Dtos.PushPlatformDtos
{
    public class PushPlatformUpdateRequest : IUpdateRequest<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProviderName { get; set; }

        public IDictionary<string, string> Config { get; set; }

        public int Priority { get; set; }

        public bool IsEnabled { get; set; }

    }
}
