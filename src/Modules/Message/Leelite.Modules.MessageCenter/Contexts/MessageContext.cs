using System;
using Leelite.Framework.Domain.Context;
using Leelite.Modules.MessageCenter.Models.MessageAgg;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;
using Leelite.Modules.MessageCenter.Models.SessionAgg;
using Microsoft.EntityFrameworkCore;

namespace Leelite.Modules.MessageCenter.Contexts
{
    public class MessageContext : EFDbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options) { }


        /// <summary>
        /// 系统消息
        /// </summary>
        public virtual DbSet<Message> Messages { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public virtual DbSet<MessageType> MessageTypes { get; set; }

        /// <summary>
        /// 消息会话
        /// </summary>
        public virtual DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.MessageAgg.Message>(b =>
            {
                //b.Ignore("Id");
                //b.HasKey("_tenantId", "_userId", "_name");
                //b.ToTable(TableConsts.SettingValue);

                //b.Property("_tenantId").HasColumnName("TenantId");
                //b.Property("_userId").HasColumnName("UserId");
                //b.Property("_name").HasColumnName("Name").HasMaxLength(256);

                //b.Property(p => p.Value).HasMaxLength(1024);

            });
        }
    }
}
