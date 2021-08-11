using Leelite.Modules.MessageCenter.Models.MessageTopicAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Modules.MessageCenter.Contexts.Configurations
{
    public class MessageTopicConfiguration : IEntityTypeConfiguration<MessageTopic>
    {
        public void Configure(EntityTypeBuilder<MessageTopic> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable(TableConsts.MessageTopic);

            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.Code).HasMaxLength(256);
            builder.Property(u => u.Icon).HasMaxLength(512);
            builder.HasEnabled();
        }
    }
}
