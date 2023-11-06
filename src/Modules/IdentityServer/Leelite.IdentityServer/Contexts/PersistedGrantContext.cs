using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.EntityFrameworkCore;

namespace Leelite.IdentityServer.Contexts
{
    public class PersistedGrantContext : PersistedGrantDbContext<PersistedGrantContext>
    {
        public PersistedGrantContext(DbContextOptions<PersistedGrantContext> options, OperationalStoreOptions storeOptions)
            : base(options)
        {
            storeOptions.PersistedGrants.Name = TableConsts.PersistedGrants;
            storeOptions.DeviceFlowCodes.Name = TableConsts.DeviceFlowCodes;
            storeOptions.ServerSideSessions.Name = TableConsts.ServerSideSessions;
            storeOptions.Keys.Name = TableConsts.Keys;
        }
    }
}
