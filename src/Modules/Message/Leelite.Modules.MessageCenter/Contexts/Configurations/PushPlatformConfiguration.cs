using Leelite.Modules.MessageCenter.Models.PlatformAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Modules.MessageCenter.Contexts.Configurations
{
    public class PushPlatformConfiguration : IEntityTypeConfiguration<PushPlatform>
    {
        public void Configure(EntityTypeBuilder<PushPlatform> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable(TableConsts.PushPlatform);

            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.Description).HasMaxLength(512);
            builder.Property(u => u.ProviderName).HasMaxLength(256);

            builder.Property(u => u.Config);
            builder.Property(u => u.Priority);
            builder.Property(u => u.IsEnabled);
        }
    }
}
