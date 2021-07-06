using Leelite.Framework.Service.Dtos;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg.Dtos.PlatformDtos
{
    public class PlatformDto : IDto<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProviderName { get; set; }

        public string Config { get; set; }

        public int Priority { get; set; }

        public bool IsEnabled { get; set; }

    }
}
