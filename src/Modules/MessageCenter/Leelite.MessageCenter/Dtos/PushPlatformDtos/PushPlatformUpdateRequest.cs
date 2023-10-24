using System.Collections.Generic;

using Leelite.Framework.Service.Dtos;

namespace Leelite.MessageCenter.Dtos.PushPlatformDtos
{
    public class PushPlatformUpdateRequest : IUpdateRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProviderName { get; set; }

        public IDictionary<string, string> Config { get; set; }

        public int Priority { get; set; }

        public bool IsEnabled { get; set; }

    }
}
