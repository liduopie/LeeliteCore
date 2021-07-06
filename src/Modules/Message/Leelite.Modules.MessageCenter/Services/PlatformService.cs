using Leelite.Framework.Domain.Command;
using Leelite.Framework.Service;
using Leelite.Modules.MessageCenter.Models.PlatformAgg.Dtos.PlatformDtos;
using Leelite.Modules.MessageCenter.Models.PlatformAgg.Interfaces;
using Leelite.Modules.MessageCenter.Models.PlatformAgg.Models.PlatformAgg;
using Leelite.Modules.MessageCenter.Models.PlatformAgg.Repositories;
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
