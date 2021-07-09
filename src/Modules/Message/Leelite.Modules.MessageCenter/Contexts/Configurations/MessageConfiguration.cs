﻿using Leelite.Modules.MessageCenter.Models.MessageAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leelite.Modules.MessageCenter.Contexts.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(u => u.Id);
            builder.ToTable(TableConsts.Message);

            builder.Property(u => u.UserId);
            builder.Property(u => u.MessageTypeId);
            builder.Property(u => u.Title).HasMaxLength(256);
            builder.Property(u => u.Description).HasMaxLength(512);
            builder.Property(u => u.Data);
            builder.Property(u => u.ReadState);
            builder.Property(u => u.DeliveryState);

            builder.HasSoftDelete();

            builder.Property(u => u.CreateTime);
            builder.Property(u => u.ReadTime);
            builder.Property(u => u.DeleteTime);
            builder.Property(u => u.ExpirationTime);
        }
    }
}