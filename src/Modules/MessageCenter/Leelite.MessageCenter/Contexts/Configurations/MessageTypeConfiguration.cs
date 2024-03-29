﻿using Leelite.MessageCenter.Models.MessageTypeAgg;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.MessageCenter.Contexts.Configurations
{
    public class MessageTypeConfiguration : IEntityTypeConfiguration<MessageType>
    {
        public void Configure(EntityTypeBuilder<MessageType> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable(TableConsts.MessageType);

            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.Code).HasMaxLength(256);
            builder.Property(u => u.Topic).HasMaxLength(256);

            builder.Property(u => u.TitleTemplate).HasMaxLength(512);
            builder.Property(u => u.DescriptionTemplate).HasMaxLength(512);

            builder.Property(u => u.Schema);
            builder.Property(u => u.PushStrategy);
            builder.Property(u => u.PushPlatform).HasColumnType("json");

            builder.Property(u => u.ValidDays);
            builder.Property(u => u.IsEnabled);
        }
    }
}
