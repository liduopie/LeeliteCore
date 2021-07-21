using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.PushPlatformDtos;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;

namespace Leelite.Modules.MessageCenter.Interfaces
{
    public interface IPushPlatformService : ICrudService<PushPlatform, int, PushPlatformDto, PushPlatformCreateRequest, PushPlatformUpdateRequest, PushPlatformQueryParameter>
    {
    }
}
