using Leelite.Modules.Identity.Models.UserClaimAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Modules.Identity.Contexts.Configurations
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasKey(uc => uc.Id);
            builder.ToTable(TableConsts.IdentityUserClaims);

            builder.Property(uc => uc.ClaimType).HasMaxLength(256);
            builder.Property(uc => uc.ClaimValue).HasMaxLength(256);
        }
    }
}
