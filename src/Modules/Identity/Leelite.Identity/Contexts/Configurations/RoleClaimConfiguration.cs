using Leelite.Identity.Models.RoleClaimAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Identity.Contexts.Configurations
{
    public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasKey(rc => rc.Id);
            builder.ToTable(TableConsts.IdentityRoleClaims);

            builder.Property(rc => rc.ClaimType).HasMaxLength(256);
            builder.Property(rc => rc.ClaimValue).HasMaxLength(256);
        }
    }
}
