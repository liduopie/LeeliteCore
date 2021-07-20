using Leelite.Framework.Domain.Context;
using Leelite.Modules.MessageCenter.Contexts.Configurations;
using Leelite.Modules.MessageCenter.Models.MessageAgg;
using Leelite.Modules.MessageCenter.Models.MessageTopicAgg;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;
using Leelite.Modules.MessageCenter.Models.PlatformAgg;
using Leelite.Modules.MessageCenter.Models.PushRecordAgg;
using Leelite.Modules.MessageCenter.Models.SessionAgg;
using Leelite.Modules.MessageCenter.Models.TemplateAgg;

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
        /// 消息主题分组
        /// </summary>
        public virtual DbSet<MessageTopic> MessageTopics { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public virtual DbSet<MessageType> MessageTypes { get; set; }

        /// <summary>
        /// 消息会话
        /// </summary>
        public virtual DbSet<Session> Sessions { get; set; }

        /// <summary>
        /// 推送平台
        /// </summary>
        public virtual DbSet<PushPlatform> PushPlatforms { get; set; }

        /// <summary>
        /// 推送记录
        /// </summary>
        public virtual DbSet<PushRecord> PushRecords { get; set; }

        /// <summary>
        /// 消息呈现模版
        /// </summary>
        public virtual DbSet<Template> Templates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new MessageTopicConfiguration());
            modelBuilder.ApplyConfiguration(new MessageTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PushPlatformConfiguration());
            modelBuilder.ApplyConfiguration(new PushRecordConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new TemplateConfiguration());
        }
    }
}
