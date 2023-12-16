using Leelite.ApiAuth.Models.ApiKeyAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.ApiAuth.Contexts.Configurations
{
    public class ApiKeyConfiguration : IEntityTypeConfiguration<ApiKey>
    {
        public void Configure(EntityTypeBuilder<ApiKey> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable(TableConsts.ApiKey);

            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Key).HasMaxLength(64).IsRequired();
            builder.Property(p => p.OwnerName).HasMaxLength(64).IsRequired();

            builder.Ignore(p => p.Claims);
            builder.Property(p => p.ClaimData).HasColumnType("jsonb");
        }
    }
}
