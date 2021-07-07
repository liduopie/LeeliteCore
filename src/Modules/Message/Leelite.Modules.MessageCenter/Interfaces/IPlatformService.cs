using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.PlatformDtos;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;

namespace Leelite.Modules.MessageCenter.Interfaces
{
    public interface IPlatformService : ICrudService<Platform, long, PlatformDto, PlatformCreateRequest, PlatformUpdateRequest, PlatformQueryParameter>
    {
    }
}
