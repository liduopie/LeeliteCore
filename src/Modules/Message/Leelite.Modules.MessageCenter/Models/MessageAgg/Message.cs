using System;
using System.Collections.Generic;

using Leelite.Framework.Domain.Aggregate;
using Leelite.Framework.Models.SoftDelete;
using Leelite.Modules.MessageCenter.Models.MessageTypeAgg;

namespace Leelite.Modules.MessageCenter.Models.MessageAgg
{
    /// <summary>
    /// 系统消息
    /// </summary>
    public class Message : AggregateRoot<long>,
        ISoftDelete
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public int MessageTypeId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 内容数据Json格式
        /// </summary>
        public IDictionary<string, string> Data { get; set; }

        /// <summary>
        /// 阅读状态:false未读、true已读
        /// </summary>
        public bool ReadState { get; set; }

        /// <summary>
        /// 送达状态:false未发送、ture已发送
        /// </summary>
        public bool DeliveryState { get; set; }

        /// <inheritdoc/>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 阅读时间
        /// </summary>
        public DateTime ReadTime { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeleteTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpirationTime { get; set; }
    }
}