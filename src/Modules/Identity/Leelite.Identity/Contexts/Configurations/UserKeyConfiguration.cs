using Leelite.Identity.Models.UserKeyAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Identity.Contexts.Configurations
{
    public class UserKeyConfiguration : IEntityTypeConfiguration<UserKey>
    {
        public void Configure(EntityTypeBuilder<UserKey> builder)
        {
            builder.HasKey(uk => uk.Id);
            builder.ToTable(TableConsts.IdentityUserKeys);

            builder.Property(uk => uk.KeyId).HasMaxLength(64);
            builder.Property(uk => uk.PublicKey).HasMaxLength(1024);
            builder.Property(uk => uk.SignatureRule).HasMaxLength(256);
            builder.Property(uk => uk.SignatureData).HasMaxLength(1024);

            builder.HasEnabled();
        }
    }
}
