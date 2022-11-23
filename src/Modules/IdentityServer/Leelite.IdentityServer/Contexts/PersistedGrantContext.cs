using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Skoruba.IdentityServer4.Admin.EntityFramework.Interfaces;

namespace Leelite.Modules.IdentityServer.Contexts
{
    public class PersistedGrantContext : PersistedGrantDbContext<PersistedGrantContext>, IAdminPersistedGrantDbContext
    {
        public PersistedGrantContext(DbContextOptions<PersistedGrantContext> options, OperationalStoreOptions storeOptions)
            : base(options, storeOptions)
        {
            storeOptions.PersistedGrants.Name = TableConsts.PersistedGrants;
            storeOptions.DeviceFlowCodes.Name = TableConsts.DeviceFlowCodes;
        }
    }
}
