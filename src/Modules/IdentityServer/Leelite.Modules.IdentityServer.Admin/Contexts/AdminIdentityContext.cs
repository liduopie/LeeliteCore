using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Modules.IdentityServer.Admin.Contexts
{
    public class AdminIdentityContext : IdentityDbContext<IdentityUser<long>, IdentityRole<long>, long, IdentityUserClaim<long>, IdentityUserRole<long>, IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public AdminIdentityContext(DbContextOptions<AdminIdentityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureIdentityContext(builder);
        }

        private void ConfigureIdentityContext(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<long>>().ToTable(TableConsts.IdentityRoles);
            builder.Entity<IdentityRoleClaim<long>>().ToTable(TableConsts.IdentityRoleClaims);
            builder.Entity<IdentityUserRole<long>>().ToTable(TableConsts.IdentityUserRoles);

            builder.Entity<IdentityUser<long>>().ToTable(TableConsts.IdentityUsers);
            builder.Entity<IdentityUserLogin<long>>().ToTable(TableConsts.IdentityUserLogins);
            builder.Entity<IdentityUserClaim<long>>().ToTable(TableConsts.IdentityUserClaims);
            builder.Entity<IdentityUserToken<long>>().ToTable(TableConsts.IdentityUserTokens);
        }
    }
}
