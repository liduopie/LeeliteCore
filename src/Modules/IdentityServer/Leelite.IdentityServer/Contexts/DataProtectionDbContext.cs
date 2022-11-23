using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Modules.IdentityServer.Contexts
{
    public class DataProtectionDbContext : DbContext, IDataProtectionKeyContext
    {
        public DataProtectionDbContext(DbContextOptions<DataProtectionDbContext> options)
            : base(options) { }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    }
}
