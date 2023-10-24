using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.PushPlatformDtos;
using Leelite.MessageCenter.Models.PushPlatformAgg;

namespace Leelite.MessageCenter.Interfaces
{
    public interface IPushPlatformService : ICrudService<PushPlatform, int, PushPlatformDto, PushPlatformCreateRequest, PushPlatformUpdateRequest, PushPlatformQueryParameter>
    {
    }
}
