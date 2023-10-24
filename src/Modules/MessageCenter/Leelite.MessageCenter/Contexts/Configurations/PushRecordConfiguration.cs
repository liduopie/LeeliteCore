using Leelite.MessageCenter.Models.PushRecordAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.MessageCenter.Contexts.Configurations
{
    public class PushRecordConfiguration : IEntityTypeConfiguration<PushRecord>
    {
        public void Configure(EntityTypeBuilder<PushRecord> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable(TableConsts.PushRecord);

            builder.Property(u => u.UserId);
            builder.Property(u => u.MessageId);
            builder.Property(u => u.PlatformId);
            builder.Property(u => u.TemplateCode).HasMaxLength(256);
            builder.Property(u => u.Content);
            builder.Property(u => u.Url);
            builder.Property(u => u.State);

            builder.Property(u => u.RetriesNum);
            builder.Property(u => u.Remark);
            builder.Property(u => u.ExpirationTime);
        }
    }
}
