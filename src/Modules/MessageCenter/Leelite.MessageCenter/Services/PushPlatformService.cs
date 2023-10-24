using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.MessageCenter.Dtos.PushPlatformDtos;
using Leelite.MessageCenter.Interfaces;
using Leelite.MessageCenter.Models.PushPlatformAgg;
using Leelite.MessageCenter.Repositories;

using Microsoft.Extensions.Logging;

namespace Leelite.MessageCenter.Services
{
    public class PushPlatformService : CrudService<PushPlatform, int, PushPlatformDto, PushPlatformCreateRequest, PushPlatformUpdateRequest, PushPlatformQueryParameter>, IPushPlatformService
    {
        public PushPlatformService(
            IPushPlatformRepository repository,
            ICommandBus commandBus,
            ILogger<PushPlatformService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
