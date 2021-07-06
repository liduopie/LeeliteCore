using Leelite.Framework.Service.Dtos;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg.Dtos.PlatformDtos
{
    public class PlatformCreateRequest : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ProviderName { get; set; }

        public string Config { get; set; }

        public int Priority { get; set; }

        public bool IsEnabled { get; set; }

    }
}
