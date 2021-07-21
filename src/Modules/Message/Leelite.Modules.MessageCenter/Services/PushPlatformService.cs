using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.PushPlatformDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;
using Leelite.Modules.MessageCenter.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.MessageCenter.Models.PushPlatformAgg.Services
{
    public class PlatformService : CrudService<PushPlatform, int, PushPlatformDto, PushPlatformCreateRequest, PushPlatformUpdateRequest, PushPlatformQueryParameter>, IPushPlatformService
    {
        public PlatformService(
            IPushPlatformRepository repository,
            ICommandBus commandBus,
            ILogger<PlatformService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
