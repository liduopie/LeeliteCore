using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Models.PlatformAgg.Dtos.PlatformDtos;
using Leelite.Modules.MessageCenter.Models.PlatformAgg.Models.PlatformAgg;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg.Interfaces
{
    public interface IPlatformService : ICrudService<Platform, long, PlatformDto, PlatformCreateRequest, PlatformUpdateRequest, PlatformQueryParameter>
    {
    }
}
