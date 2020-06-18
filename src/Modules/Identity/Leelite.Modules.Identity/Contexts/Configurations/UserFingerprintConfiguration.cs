using Leelite.Modules.Identity.Models.UserFingerprintAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Modules.Identity.Contexts.Configurations
{
    public class UserFingerprintConfiguration : IEntityTypeConfiguration<UserFingerprint>
    {
        public void Configure(EntityTypeBuilder<UserFingerprint> builder)
        {
            builder.HasKey(uf => uf.Id);
            builder.ToTable(TableConsts.IdentityUserFingerprints);

            builder.Property(uf => uf.FingerName).HasMaxLength(64);
            builder.Property(uf => uf.Fingerprint).HasMaxLength(1024);

            builder.HasEnabled();
        }
    }
}
