using Leelite.MessageCenter.Models.SessionAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.MessageCenter.Contexts.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable(TableConsts.Session);

            builder.Property(u => u.MessageTypeId);
            builder.Property(u => u.Title).HasMaxLength(256);
            builder.Property(u => u.Description).HasMaxLength(512);
            builder.Property(u => u.Data).HasColumnType("json");
            builder.Property(u => u.UserIds).HasColumnType("json");
            builder.Property(u => u.UserNum);
            builder.Property(u => u.PushNum);

            builder.Property(u => u.CreateTime);
            builder.Property(u => u.State);
            builder.Property(u => u.CompleteTime);
            builder.Property(u => u.ExpirationTime);

            builder.Property(u => u.Remark);
        }
    }
}
