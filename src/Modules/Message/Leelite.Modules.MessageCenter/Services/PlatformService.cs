using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Dtos.PlatformDtos;
using Leelite.Modules.MessageCenter.Interfaces;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;
using Leelite.Modules.MessageCenter.Repositories;
using Microsoft.Extensions.Logging;

namespace Leelite.Modules.MessageCenter.Models.PlatformAgg.Services
{
    public class PlatformService : CrudService<Platform, long, PlatformDto, PlatformCreateRequest, PlatformUpdateRequest, PlatformQueryParameter>, IPlatformService
    {
        public PlatformService(
            IPlatformRepository repository,
            ICommandBus commandBus,
            ILogger<PlatformService> logger
            ) : base(repository, commandBus, logger)
        {
        }
    }
}
